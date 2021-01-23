        private void LoadAttractions()
        {
            if (cbxAttractions.IsChecked != false)
            {
                Attractions attractions = new Attractions();
                foreach (var attraction in Attractions.allAttractions)
                {
                    Pushpin pushpin = new Pushpin();
                    pushpin.Name = attraction.Title;
                    pushpin.GeoCoordinate = new GeoCoordinate(attraction.Latitude, attraction.Longtitude);
                    pushpin.Content = attraction.Title;
                    pushpin.Background = new SolidColorBrush(Colors.Yellow);
                    pushpin.Foreground = new SolidColorBrush(Colors.Black);
                    MapOverlay MyOverlay = new MapOverlay();
                    mapLayerAttractions.Add(MyOverlay);
                    MyOverlay.Content = pushpin;
                    MyOverlay.GeoCoordinate = new GeoCoordinate(attraction.Latitude, attraction.Longtitude);
                    MyOverlay.PositionOrigin = new Point(0.0, 1.0);
                }
                MainMap.Layers.Add(mapLayerAttractions);
            }
        }
