            var overlay = new MapOverlay { PositionOrigin = new Point(0.5, 0.5), GeoCoordinate = coordinate };
	    
            var img = new Image { Width = 56, Height = 56 };
            img.Source = new BitmapImage { UriSource = new Uri("/Assets/Icons/pin.png", UriKind.Relative) };
            img.Tag = coordinate;
            img.Tap += delegate
            {
                // handle tap
            };
            overlay.Content = img;
            var mapLayer = new MapLayer { overlay };
            map.Layers.Add(mapLayer);
