      private void GetCoordinate()
        {
            var watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High)
            {
                MovementThreshold = 2
            };
            watcher.PositionChanged += this.watcher_PositionChanged;
            watcher.StatusChanged += this.watcher_StatusChanged;
            watcher.Start();
        }
    private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            try
            {
                var pos = e.Position.Location;
                if(position==required one)
                 {
                    //enable disable here  
                 }
                StaticData.currentCoordinate = new GeoCoordinate(pos.Latitude, pos.Longitude);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
