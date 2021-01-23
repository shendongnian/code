    Image imgPushpin = new Image();
                            imgPushpin.Height = 60;
                            imgPushpin.Width = 41;
                            imgPushpin.Source = new BitmapImage(new Uri("/Assets/Images/PropertyLocator/imgPropertyPoint.png", UriKind.Relative));
                            imgPushpin.Tag = "Location";
                            imgPushpin.MouseLeftButtonUp += imgPushpinMouseLeftButtonUp;
                            // Create a MapOverlay and add marker
                            MapOverlay overlay = new MapOverlay();
                            overlay.Content = imgPushpin;
                            overlay.GeoCoordinate = new GeoCoordinate(listView[j].latitude, listView[j].longnitude);
                            overlay.PositionOrigin = new Point(0.5, 1);
                            locationLayer = new MapLayer();
                            locationLayer.Add(overlay);
                            mapPropertyLocator.Layers.Add(locationLayer);
                            mapPropertyLocator.ZoomLevel = 11.5;
