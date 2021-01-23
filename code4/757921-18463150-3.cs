    var table = dt.Clone().AsEnumerable()
                          .GroupBy(row=>row["ITEM"])
                          .Select(g=> {
                                    DataRow dr = g.First();
                                    dr.SetField("QTY", g.Sum(x=>x.Field<int>("QTY")));
                                    return dr;
                                 })
                          .CopyToDataTable();
