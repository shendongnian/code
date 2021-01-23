    var rowNotIntable1 = table3.AsEnumerable().Select(r => r.Field<string>("col1"))
                                                  .Except(table1.AsEnumerable().Select(r =>r.Field<string>("col1")));
                
                                    if (rowNotIntable1 .Count() > 0)
                                    {
                                        DataTable dt = (from row in table3.AsEnumerable()
                                                        join id in rowNotIntable1 
                                                            on row.Field<string>("col1") equals id
                                                        select row).CopyToDataTable();
                }
        foreach (DataRow row in dt.Rows)
                                        {
                table1.ImportRow(row);
                table1.AcceptChanges();
            
            }
