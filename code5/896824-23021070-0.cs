      this.DestinationsList.Clear();
           // Add all results to MyCoordinates for drawing the map markers
           for (int i = 0; i < e.Result.Count; i++)
           {
                MyCoordinates.Add(e.Result[i].GeoCoordinate);
                MapAddress address = e.Result[0].Information.Address;
                String stringAddress = address.City;
                if (i < 6) {
                    this.DestinationsList.Add(stringAddress);
                }
                               
           }
