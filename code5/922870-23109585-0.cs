    private void Maps_ReverseGeoCoding(object sender, RoutedEventArgs e)
    {
        ReverseGeocodeQuery query = new ReverseGeocodeQuery()
        {
            GeoCoordinate = new GeoCoordinate(YourLatitude, YourLongitude)
        };
        query.QueryCompleted += query_QueryCompleted;
        query.QueryAsync();
    }
    
    void query_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
    {
        StringBuilder placeString = new StringBuilder();
        foreach (var place in e.Result)
        {
            placeString.AppendLine(place.GeoCoordinate.ToString());
            placeString.AppendLine(place.Information.Name);
            placeString.AppendLine(place.Information.Description);
            placeString.AppendLine(place.Information.Address.BuildingFloor);
            placeString.AppendLine(place.Information.Address.BuildingName);
            placeString.AppendLine(place.Information.Address.BuildingRoom);
            placeString.AppendLine(place.Information.Address.BuildingZone);
            placeString.AppendLine(place.Information.Address.City);
            placeString.AppendLine(place.Information.Address.Continent);
            placeString.AppendLine(place.Information.Address.Country);
            placeString.AppendLine(place.Information.Address.CountryCode);
            placeString.AppendLine(place.Information.Address.County);
            placeString.AppendLine(place.Information.Address.District);
            placeString.AppendLine(place.Information.Address.HouseNumber);
            placeString.AppendLine(place.Information.Address.Neighborhood);
            placeString.AppendLine(place.Information.Address.PostalCode);
            placeString.AppendLine(place.Information.Address.Province);
            placeString.AppendLine(place.Information.Address.State);
            placeString.AppendLine(place.Information.Address.StateCode);
            placeString.AppendLine(place.Information.Address.Street);
            placeString.AppendLine(iplaceem.Information.Address.Township);
        }
        MessageBox.Show(placeString.ToString());
    }
