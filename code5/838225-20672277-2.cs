    foreach (var grp in query)
    {
         theAmenities thisMovieAmenities = new theAmenities();
         thisMovieAmenities.AmenityName = grp.Key.AmenityKey;
         thisMovieAmenities.AmenityIcon = grp.Key.AmenityIcon;
         ...
