        private void setPinsOnTheMap()
        {
            MapLayer layer = new MapLayer();
            for (int i = 0; i < elementsList.Count; i++)
            {
                Pushpin pin = new Pushpin();
                pin.GeoCoordinate = elementsList.ElementAt(i).geoLocation;
                MapOverlay overlay = new MapOverlay();
                overlay.GeoCoordinate = elementsList.ElementAt(i).geoLocation;
                overlay.Content = pin;
                layer.Add(overlay);
            }
            map.Layers.Add(layer);
        }
