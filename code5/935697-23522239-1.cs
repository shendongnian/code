    using (var bulkCopy = new SqlBulkCopy(conn, <SqlBulkCopyOptions>))
                {
                    //dataTable definition
                    var table = new System.Data.DataTable();
                    table.Columns.Add("object_name", typeof(string));
                    table.Columns.Add("object_id", typeof(int));
                    table.Columns.Add("object_xpath", typeof(string));
                    table.Columns.Add("time", typeof(DateTime));
                    //bulkCopy options
                    bulkCopy.BatchSize = webidsAndXPaths.Count();
                    bulkCopy.DestinationTableName = "CorporateDataStructure.dbo.ObjectInventory";
                    //bulkCopy mappings (not mandatory, just to avoid depending on column ordering in datatable)
                    //That may avoid "strange" mistakes if you change something to your db or datatable.
                    bulkCopy.ColumnMappings.Add("object_name", "object_name");
                    bulkCopy.ColumnMappings.Add("object_id", "object_id");
                    bulkCopy.ColumnMappings.Add("object_xpath", "object_xpath");
                    bulkCopy.ColumnMappings.Add("time", "time");
    
                    //dataTable fedding from dictionary
                    foreach (var pair in webidsAndXPaths)
                    {
                         table.Rows.Add(objectName, pair.Key, pair.Value, dt);
                    }
                    //write to db.
                    bulkCopy.WriteToServer(table);
                }
