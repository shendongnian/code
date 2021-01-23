    var total = (from x in db
                 group x by new { x.Date.Year, x.Date.Month, x.UserId } into grp
                 select new
                 {
                     grp.Key.UserId,
                     grp.Key.Month,
                     grp.Key.Year,
                     Total = grp.Sum(x => x.Hours)
                 }).ToList();
