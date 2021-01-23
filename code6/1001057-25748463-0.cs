            // Create source connection
            using (
                var source =
                    new SqlConnection(
                        String.Format(
                            @"Data Source=(LocalDB)\v11.0;AttachDbFilename={0};Integrated Security=True;",
                            preDatabase)))
            {
                source.Open();
                // Create destination connection
                using (var destination = new SqlConnection(Settings.Default.mdcdbConnectionString))
                {
                    destination.Open();
                    DataTable dt = source.GetSchema("Tables");
                    foreach (string tablename in from DataRow row in dt.Rows select (string) row[2])
                    {
                        App.Logger.LogText(String.Format("Copying table {0}", tablename));
                        using (var cmd = new SqlCommand(String.Format("TRUNCATE TABLE {0}", tablename), destination))
                        {
                            cmd.ExecuteNonQuery();
                            //App.Logger.LogText(String.Format("truncate table {0}", tablename));
                        }
                        using (var cmd = new SqlCommand(String.Format("SELECT * FROM {0}", tablename), source))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                var bulkData = new SqlBulkCopy(destination)
                                    {
                                        DestinationTableName = tablename
                                    };
                                // Set destination table name
                                bulkData.WriteToServer(reader);
                                // Close objects
                                bulkData.Close();
                                //App.Logger.LogText(String.Format("Copy success {0}", tablename));
                            }
                        }
                    }
                    destination.Close();
                }
                source.Close();
            }
