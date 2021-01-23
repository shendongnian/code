    string sDataTableOutput = string.Join("|", 
                               dtGraphOutput[0].Columns
                                               .OfType<DataColumn>()
                                               .Select((c,i) =>
                                                  string.Join(",",
                                                  dtGraphOutput[0].Rows
                                                                  .OfType<DataRow>()
                                                                  .Select((r,j)=>
                                                              (j == 0 && i != 0 ? c.ColumnName + "," : "") + c.Field<string>(c.ColumnName)
                                                                  .ToArray())).ToArray());
                                                                                 .
