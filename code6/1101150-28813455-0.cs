    var query = (from t in trains
                 group t.Carriages by t.Country.ToUpper()
                 into g
                 select new
                 {
                     Country = g.Key,
                     TotalCarriages = g.Count(),
                     SumCarriage = g.SelectMany(c => c).Sum(l => l.Length)
                 }).ToList();
