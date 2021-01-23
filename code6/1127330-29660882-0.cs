    // This is so you can run a single minimal query to select
    // all the facilities you'll be working with
    var facNames = Facilities.Select(m => m.Replace(".", " "));
    var facList = db.zFacilities.Where(m => facNames.Contains(m.FacilityName)).ToList();
    // Now add all facilities not currently attached
    facList.Where(m => !zrequest.zFacility.Contains(m)).ToList()
        .ForEach(m => zrequest.zFacility.Add(m));
