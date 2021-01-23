    var table = dt.AsEnumerable()
                  .GroupBy(row=>row["ITEM"])
                  .Select(g=> {
                              DataRow dr = g.First();
                              g.SetField("QTY", g.Sum())
                            })
                  .CopyToDataTable();
