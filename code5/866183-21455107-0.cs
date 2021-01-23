    table.AsEnumerable()
         .GroupBy(r => r.Field<DateTime>("SCANEDATE"))
         .Select(g = new {
              ScanDate = g.Key,
              Ids = String.Join(",", g.Select(r => r.Field<int>("IIMAGEID"))),
              Count = g.Count()
          });
                     
