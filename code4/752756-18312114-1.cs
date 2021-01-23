    string sDataTableOutput = string.Join("|", 
                               dtGraphOutput[0].Columns
                                               .OfType<DataColumn>()
                                               .Select((c,i) =>
                                                  string.Join(",",
                                                  dtGraphOutput[0].Rows
                                                                  .OfType<DataRow>()
                                                                  .Select((r,j)=>
                                                              (j == 0 && i != 0 ? c.ColumnName + "," : "") + r.Field<int>(c.ColumnName).ToString())
                                                                  .ToArray())).ToArray());
                                                                                 .
