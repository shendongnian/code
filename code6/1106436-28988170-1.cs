     using (var db = new DbContext1())
     {
       var query = (from driver in db.Drivers
                    join drp in db.DriverRacePoints on driver.Id equals drp.Driver_Id
                    join race in db.Races on drp.Race_Id equals race.Id
                    group new {driver,drp, race} by driver.Id into g
                    select new {DriverId=g.Key,// The driver Id
                                RacesWithPoints=g.Select(a=>new {a.race,a.drp.Points}),// All the races ( and the points X race) where the driver participates
                                TotalPoints=g.Sum(a=>a.drp.Points)// Total of points
                               });
       //use the data you get from this query
     }
