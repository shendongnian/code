    private void Map_PinDragging(object sender, PinDragEventArgs e)
    {
        int m = map.Pins.IndexOf(e.Pin);
        map.Pins.ElementAt(m).Position = new Xamarin.Forms.GoogleMaps.Position(e.Pin.Position.Latitude - (0.001347153801 * 0.5), e.Pin.Position.Longitude);
    }
    private void Map_PinDragStart(object sender, PinDragEventArgs e)
    {
        int m = map.Pins.IndexOf(e.Pin);
        map.Pins.ElementAt(m).Position = new Xamarin.Forms.GoogleMaps.Position(e.Pin.Position.Latitude - (0.001347153801 * 0.5), e.Pin.Position.Longitude);
    }
    Pin DragPin;
    private void Map_PinDragEnd(object sender, PinDragEventArgs e)
    {
        int m = map.Pins.IndexOf(e.Pin);
        map.Pins.ElementAt(m).Position = new Xamarin.Forms.GoogleMaps.Position(e.Pin.Position.Latitude - (0.001347153801*0.5), e.Pin.Position.Longitude);
    }
