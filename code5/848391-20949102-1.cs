    var mydic = table3.AsEnumerable()
                      .GroupBy(r => r.Field<string>("RowOrder")
                      .Select(g => g.First())
                      .ToDictionary(r => r.Field<string>("RowOrder"),
                                         r.Field<string>("Value"));
