    var query = db.UserLocations
                .GroupBy(l => l.UserID)
                .Select(g =>
                         new ModelLocation
                                {
                                   UserID = g.Key,
                                   Locations = g.Select(l => l.Location).ToArray()
                                });
