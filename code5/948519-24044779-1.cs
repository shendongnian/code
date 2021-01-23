                var table = new DataTable(); // create the datatable
               
                table.Columns.Add("location", typeof (string));
                table.Columns.Add("product_name", typeof (string));
                table.Columns.Add("product_id", typeof (string));
                table.Columns.Add("object_price", typeof (string));
                table.Columns.Add("session_id", typeof (string));
                
                
                foreach (var pair in webidsAndXPaths) // then loop all dictionary entries and add the rows
                {
                    table.Rows.Add(location, productName, pair.Key, pair.Value, sessionId);
                }
                
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    // Set up the column mappings by name.
                    var l = new SqlBulkCopyColumnMapping("location", "location");
                    var pn = new SqlBulkCopyColumnMapping("product_name", "product_name");
                    var pid = new SqlBulkCopyColumnMapping("product_id", "product_id");
                    var pp = new SqlBulkCopyColumnMapping("product_price", "product_price");
                    var sid = new SqlBulkCopyColumnMapping("session_id", "session_id");
                    
                    bulkCopy.ColumnMappings.Add(l);
                    bulkCopy.ColumnMappings.Add(pn);
                    bulkCopy.ColumnMappings.Add(pid);
                    bulkCopy.ColumnMappings.Add(pp);
                    bulkCopy.ColumnMappings.Add(sid);
                   
                    // destinationDatabase = "dbo.ObjectInventory"
                    bulkCopy.DestinationTableName = destinationDatabase;
                    conn.Open();
                    bulkCopy.WriteToServer(table); // write to database
                    conn.Close();
                }
               
                return true;
