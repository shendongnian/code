    var groupedResults= from r in dataTable.AsEnumerable()
                      group r by r.Field<string>("Id") into g
                      select new
                      {
                          Id = g.Key,
                          Name = g.Min(),
                          Product = g.Count()
                      };
