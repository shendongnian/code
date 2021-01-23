      var query3 = (from driver in db.Drivers
                    join drp in db.DriverRacePoints on driver.Id equals drp.Driver_Id
                    from race in db.Races
                    where race.RaceStart.Year == 2014
                    select new {  driver,drp, race })
                   .GroupBy(e => e.driver.Id)
                   .Select(g => new
                    {
                        DriverName = g.FirstOrDefault().driver.Name,
                        RacesWithPoints = g.Select(a => new { a.race.Name, Points = a.drp.Race_Id == a.race.Id ? 0 : a.drp.Points }), // All the races (if the driver  was involved => you have the Points value, otherwise, the value is 0 )
                        TotalPoints = g.Sum(a => a.drp.Points)// Total of points
                    }).OrderByDescending(e=>e.TotalPoints);
