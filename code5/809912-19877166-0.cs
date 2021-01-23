    var newTable = oldTable.Clone();
    newTable.Columns.Add("NewColumn");
    newTable = oldTable.AsEnumerable()
                       .GroupBy(row => row.Field<string>("userID"))
                       .Select(g => {
                          var newRow = newTable.NewRow();
                          var firstRow = g.First();
                          for(int i = 0; i < 4; i++) newRow[i] = firstRow[i];
                          newRow["NewColumn"] = string.Join(", ", 
                                                g.Select(row=>row.Field<string>("ProductCode")
                                                         + ", " + row.Field<decimal>("ProductValue")));
                          return newRow;
                        }).CopyToDataTable();
