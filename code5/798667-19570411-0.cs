    var popPlace = 
        from places in sqlPlaceResults.AsEnumerable()
            join placeAll in sqlPlaceResultsAll.AsEnumerable() 
                on places["PLACEID"] equals placeAll["PLACEID"] into placeAllVals
        from sub in placeAllVals.DefaultIfEmpty()
        select new Place
        {
            PlaceName = regions["NAME"].ToString(),
            PlaceId = (Int32)regions["PLACEID"],
            Ischecked = sub != null
        };
