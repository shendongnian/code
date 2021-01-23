    var conn = new SqlConnection(masterData.DictRunData["ConnectionStringLocalDb"]);
                const string objectName = "NotAvailable";
                var dateTime = DateTime.Now;
                
                // create the datatable
                var table = new DataTable();
                table.Columns.Add("location", typeof(string));
                table.Columns.Add("object_name", typeof(string));
                table.Columns.Add("object_id", typeof(string));
                table.Columns.Add("object_xpath", typeof(string));
                table.Columns.Add("time", typeof (DateTime));
                // then loop all dictionary entries and add the rows
                foreach (var pair in webidsAndXPaths)
                {
                    table.Rows.Add(location, objectName, pair.Key, pair.Value, dateTime);
                }
                // finally write the data to the sql server
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    conn.Open();
                    bulkCopy.DestinationTableName = "dbo.ObjectInventory";
                    bulkCopy.WriteToServer(table);
                }
