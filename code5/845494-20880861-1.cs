    var aa = _DatabaseContext.VAHistories
        .GroupBy(gg => gg.person_id).Select(c => c.OrderByDescending(m => m.update_date).First())
        .GroupBy(a => SqlFunctions.DatePart("dy", a.update_date))
        .Select(g => new
                {
                    Name = g.Key,
                    Status0= g.Where(c => c.status_id == 0).Count(),
                    Status1= g.Where(c => c.status_id == 1).Count(),
                    Status2= g.Where(c => c.status_id == 2).Count(),
                    Status4= g.Where(c => c.status_id == 4).Count(),
                    Status3= g.Where(c => c.status_id == 5).Count()
                })
        .ToList<object>();
