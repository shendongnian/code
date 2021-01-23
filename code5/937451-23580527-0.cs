    context.Hotels
        .Where(h => h.HotelType.Split("|").Select(ht=>int.Parse(ht))
        .Contains(s.HotelTypeId))
        .Select(hotel => new Model.Hotel
           {
              HotelId = hotel.HotelID,
              HotelName = hotel.HotelName,
              HotelFileName = hotel.HotelFileName,
              StarRating = hotel.StarRating,
              CountryName = hotel.Country.CountryName,
              PlaceName = hotel.Place.PlaceName
           });
