     var queryable= from item in <Table1>
                     group item by item.name into g
                     select new {
                        name =m.Key,
                        allDebit = m.Sum(x => x.debit
                     }
       var result = queryable.ToList()
                     .Select((g, rn) => new {
                          g.name,
                          g.allDebit
                          rn
                      });
