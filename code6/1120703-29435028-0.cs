    var f = from c in Customer
                        .GroupBy(b=>new { b.Firstname,b.Lastname})
                        .Select(g => new { 
                                 Metric = g.Key, 
                                 Count = g.Count() 
                       })
            select c;
