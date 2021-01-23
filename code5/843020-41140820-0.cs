     _watcher = new GeoCoordinateWatcher();
     _watcher.TryStart(true, TimeSpan.FromMilliseconds(1000));
     _watcher.PositionChanged += watcher_PositionChanged;
     void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (e.Position.Location != null)
            {
                Console.WriteLine("Lat: {0}, Long: {1}",
                    e.Position.Location.Latitude,
                    e.Position.Location.Longitude);
                _watcher.Stop();
            }
        }
