    #if never
        public static void StartReverseGeoCoding( GeoCoordinate Location )
            {
            var reverseGeocode = new ReverseGeocodeQuery();
            reverseGeocode.GeoCoordinate = new GeoCoordinate( Location.Latitude, Location.Longitude );
            reverseGeocode.QueryCompleted += ReverseGeocodeQueryCompleted;
            reverseGeocode.QueryAsync();
            }
        public static void ReverseGeocodeQueryCompleted( object sender, QueryCompletedEventArgs<System.Collections.Generic.IList<MapLocation>> e )
            {
            var reverseGeocode = sender as ReverseGeocodeQuery;
            if ( reverseGeocode != null )
                {
                reverseGeocode.QueryCompleted -= ReverseGeocodeQueryCompleted;
                }
            // Microsoft.Phone.Maps.Services.MapAddress address; 				
            Addresses.Clear();
            if ( !e.Cancelled )
                {
                foreach ( var address in e.Result.Select( adrInfo => adrInfo.Information.Address ) )
                    {
                    Addresses.Add( string.Format( "{0} {1}, {2} {3} {4}, {5}",
                      address.HouseNumber,
                      address.Street,
                      address.City,
                      address.State,
                      address.PostalCode,
                      address.Country ).Trim() );
                    }
                }
            Address = ( Addresses.Count > 0 ) ? Addresses[ 0 ].ToString() : string.Empty;
            }
