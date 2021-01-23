    var table = dt.AsEnumerable()
                  .GroupBy(row=>row["ITEM"])
                  .Select(g=> {
                              DataRow dr = g.First();
                              dr.SetField("QTY", g.Sum())
                            })
                  .CopyToDataTable();
