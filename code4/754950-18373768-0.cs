    from spl in SpeciesLists 
                 join ar in Areas on spl.Station.Area equals ar.Id 
                 join ground  in Grounds on ar.Ground equals ground.Id 
                 join re in Regions on ground.Region  equals re.Id 
                 where spl.Station.Trip.year ==2013
        		 && spl.Station.Trip.ProtectedArea == 1
        		 group spl by new { slp.Description, ar.description, ground.Code } into Result
                 select new 
                   {
                      SpciesCommonName = Result.Key.Description,
                      Are = Result.Key.description,
                      Ground = Result.Key.Code,
                      NumberOfTripsInProtectedAreas = Result.Count()
                   }
