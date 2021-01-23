    var query = from r in table.AsEnumerable()
                group r by new { 
                   Company = r.Field<string>("Company"),
                   Manager = r.Field<string>("Manager"),
                   Location = r.Field<string>("Location")
                } into g
                select new {
                   g.Key.Company,
                   g.Key.Manager,
                   g.Key.Location,
                   Count1 = g.Sum(r => r.Field<int>("Count1"),
                   Count2 = g.Sum(r => r.Field<int>("Count2"),
                   Count3 = g.Sum(r => r.Field<int>("Count3")
                };
