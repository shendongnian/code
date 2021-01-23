    var markers = new List<Marker>();
    
    userList.ForEach(user =>
    {
        var country = CountriesHandler
                        .GetCountry(user.GetAttributeValue<string> ("Country"));
        markers.AddRange(photoWithInfo.Where(info => user.Id == info.UserID)
            .Select(info => new Marker
                {
                    Id = info.UserID,
                    Image = info.SquareThumbnailUrl,
                    Latitude = country.Latitude,
                    Longitude = country.Longitude
                 }));
        });
