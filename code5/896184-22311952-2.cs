            var overlay = new MapOverlay
            {
                PositionOrigin = new Point(0.5, 0.5),
                GeoCoordinate = location, // takes a GeoCoordinate instance. convert Geoposition to GeoCoordinate
                Content = new TextBlock{Text = "hello"}; // you can use any UIElement as a pin
            };
            var ml = new MapLayer { overlay }; 
            map.Layers.Add(ml);
