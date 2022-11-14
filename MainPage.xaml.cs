using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace MarkerTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();        
    }

    protected override async void OnAppearing()
    {
        Pin pin = new()
        {
            Label = "Melbourne",
            Type = PinType.Place,
            Location = new(-37.84, 144.94)
        };

        map.Pins.Add(pin);
        
        pin.MarkerClicked += (s, args) =>
        {
            Pin pin = (Pin)s;
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(pin.Location, Distance.FromKilometers(1));

            map.MoveToRegion(mapSpan);
        };

        MapSpan span = MapSpan.FromCenterAndRadius(new(-37.02, 144.96), Distance.FromKilometers(250));
        map.MoveToRegion(span);
    }
}

