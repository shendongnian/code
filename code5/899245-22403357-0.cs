    public static List<PlaceMap> GetPlace(this IEnumerable<Place> places, string hotelName, ref DataEntities ctx)
    {
        var place= ctx.places
            .Where(h=>h.HotelName==hotelName)
            .Select(s => new PlaceMap
            {
                PlaceName= s.PlaceName,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                NearByPlaces = ctx.places.Where
                (
                    x=>
                    DbGeography.FromText("POINT(" + s.Longitude + " " + s.Latitude + ")")  
                    .Distance
                    (
                        DbGeography.FromText("POINT(" + x.Longitude + " " + x.Latitude + ")")
                    ) < YourRadiousInMeters
                )                  
            }).SingleOrDefault();
        return place;
    }
