    ReverseGeocodeQuery reverseGeocode = new ReverseGeocodeQuery();
    reverseGeocode.GeoCoordinate = new GeoCoordinate(gCordinate.Latitude, gCordinate.Longitude);
    reverseGeocode.QueryCompleted += reverseGeocode_QueryCompleted;
    reverseGeocode.QueryAsync();
    void reverseGeocode_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
    {
        try
        {
            if (e.Cancelled)
            {
                txtCompleteAddress.Text = "operation was cancelled";
            }
            else if (e.Error != null)
            {
                txtCompleteAddress.Text = "Error: " + e.Error.Message;
            }
            else if (e.Result != null)
            {
                if (e.Result.Count > 0)
                {
                    MapAddress geoAddress = e.Result[0].Information.Address;
                    addressString1 = geoAddress.HouseNumber + " " + geoAddress.Street;
                    addressString2 = geoAddress.District + ", " + geoAddress.City;
                    addressString3 = geoAddress.Country;
                    if (addressString1 != " ")
                        addressString1 = addressString1 + "\n";
                    else
                        addressString1 = "";
                    if (addressString2 != ",  ")
                        addressString2 = addressString2 + "\n";
                    else
                        addressString2 = "";
                    txtCompleteAddress.Text = addressString1 + addressString2 + addressString3;
                }
                else
                {
                    txtCompleteAddress.Text = "no address found at that location";
                }
            }
        }
        catch
        {
            MessageBox.Show("Some error occured in converting location geo Coordinates to location address, please try again later");
        }
    }
