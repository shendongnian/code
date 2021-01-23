    var result= _dbEntities.Bills.Where(b => b.Year == year)
                                 .GroupBy(b => b.MonthId)
                                 .Select(g=> new { MonthId=g.Key,
                                                   Phone=g.Sum(b=>b.Phone),
                                                   Water = g.Sum(b => b.Water),
                                                   Gas = g.Sum(b => b.Gas),
                                                   Electricity = g.Sum(b => b.Electricity)                                         
                                                 }).ToList();
