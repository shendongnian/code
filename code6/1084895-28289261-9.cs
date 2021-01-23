        async Task ContinueAsync()
        {
            Geolocator Locator = new Geolocator();
            Geoposition Position = await Locator.GetGeopositionAsync();
            Geocoordinate Coordinate = Position.Coordinate; 
        
            // ...
        
            var messageDialog = new Windows.UI.Popups.MessageDialog("Hello");
            await messageDialog.ShowAsync();
        
            // ...
        }
