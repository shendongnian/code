       pushpin.Tap += (s, eve) =>
          {
            MapView.SetView(pushpin.Location,MapView.ZoomLevel);
            var pushpinModel = (s as Pushpin).DataContext;
            GeoCoordinate pinLocation = new GeoCoordinate();
            pinLocation = pushpin.Location;
            pin.PositionOrigin = new PositionOrigin(-0.3,0.7);
            pin.Location = pinLocation;
            MapView.Children.Add(pin);
          }
