    var popPlace = 
        from placeAll in sqlPlaceResultsAll.AsEnumerable()
        select new Place
        {
            placeName = regions["NAME"].ToString(),
            PlaceId = (Int32)regions["PLACEID"],
            Ischecked = sqlPlaceResults.AsEnumerable().Any(
                places => places["PLACEID"] == placeAll["PLACEID"])
        };
