    Depots
        .Where(d => d.DepotTypeId == id)
        .AsEnumerable()
        .Select(d => new {
            DepotId = d.DepotId,
            GpsLatitude = d.GpsLatitude,
            GpsLongitude = d.GpsLongitude,
            LocationName = HttpUtility.HtmlEncode(d.DepotName)
        });
            
