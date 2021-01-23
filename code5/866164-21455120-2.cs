       var result =
                new DataTable().Rows.Cast<DataRow>()
                    .Select(p => new 
                              {
                                  User = p.Field<string>("column1Name"), 
                                  Q = p.Field<string>("column2Name"), 
                                  Value = p.Field<double>("column3Name")
                              })
                    .GroupBy(p => new {p.User, p.Q})
                    .Select(p => new {User = p.Key.User, Q = p.Key.Q, Total = p.Sum(x => x.Value)})
                    .ToList();
