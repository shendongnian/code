       var result = (from b in myDataTable.AsEnumerable()
                          group b by b.Field<string>("Your_Column_Name") into g
                          select new
                          {
                              ColumnValue= g.Key,
                              LastRow = g.Last()
                          }).ToList();
