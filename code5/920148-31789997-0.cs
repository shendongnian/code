        private void findAddress(GeoCoordinate myCoordinate)
        {
            if (reverseGeocode != null) reverseGeocode = null;
            reverseGeocode = new ReverseGeocodeQuery();
            reverseGeocode.GeoCoordinate = myCoordinate;
            reverseGeocode.QueryCompleted += reverseGeocode_QueryCompleted;
            reverseGeocode.QueryAsync();
        }
        void reverseGeocode_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            if (e.Error == null && e.Result.Count > 0)
            {
                //Here you got all information about your current coordinate/position
                MapAddress myPositionAddress = null;
                myPositionAddress = e.Result.FirstOrDefault().Information.Address;
            }
        }
