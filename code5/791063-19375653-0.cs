    var result = from pwi in photoWithInfo
                         join user in userList on pwi.UserId equals user.UserId
                         select new Marker()
                         {
                             Id = user.UserId,
                             Image = pwi.SquareThumbnailUrl,
                             Longitude = CountriesHandler.GetCountry(user.GetAttributeValue<string>("Country")).Longitude,
                             Latitude = CountriesHandler.GetCountry(user.GetAttributeValue<string>("Country")).Latitude
                         };
