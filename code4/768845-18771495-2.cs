            public static Task<string> StartReverseGeoCodingAsync( System.Device.Location.GeoCoordinate Location )
            {
            var reverseGeocode = new ReverseGeocodeQuery();
            reverseGeocode.GeoCoordinate = new System.Device.Location.GeoCoordinate( Location.Latitude, Location.Longitude );
            var tcs = new TaskCompletionSource<string>();
            EventHandler<QueryCompletedEventArgs<System.Collections.Generic.IList<MapLocation>>> handler = null;
            handler = ( sender, args ) =>
            {
                if ( args.Error != null )
                    {
                    tcs.SetException( args.Error );
                    }
                else if ( args.Cancelled )
                    {
                    tcs.SetCanceled();
                    }
                else
                    {
                    Addresses.Clear();
                    foreach ( var address in args.Result.Select( adrInfo => adrInfo.Information.Address ) )
                        {
                        Addresses.Add(
                            string.Format( "{0} {1}, {2} {3} {4}, {5}",
                                           address.HouseNumber,
                                           address.Street,
                                           address.City,
                                           address.State,
                                           address.PostalCode,
                                           address.Country ).Trim() );
                        }
                    string Address = Addresses.Count > 0 ? Address = Addresses[ 0 ].ToString() : string.Empty;
                    reverseGeocode.QueryCompleted -= handler;
                    tcs.SetResult( Address );
                    }
            };
            reverseGeocode.QueryCompleted += handler;
            reverseGeocode.QueryAsync();
            return tcs.Task;
            }
