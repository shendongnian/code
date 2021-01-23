    var mydic = table3.AsEnumerable()
                      .GroupBy(r => r.Field<string>("RowOrder"))
                      .Select(g => g.First()) // or last to use last value for key
                      .ToDictionary(r => r.Field<string>("RowOrder"),
                                         r.Field<string>("Value"));
