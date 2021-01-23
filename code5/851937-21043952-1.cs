    var query = from x in db.TableName
                group r by new { 
                   x.Company,
                   x.Manager,
                   x.Location
                } into g
                select new {
                   g.Key.Company,
                   g.Key.Manager,
                   g.Key.Location,
                   Count1 = g.Sum(x => x.Count1),
                   Count2 = g.Sum(x => x.Count2),
                   Count3 = g.Sum(x => x.Count3)
                };
