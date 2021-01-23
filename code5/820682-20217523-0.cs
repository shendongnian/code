        private void DropDatabase(string connectionString)
        {
            var bld = new SqlConnectionStringBuilder(connectionString);
            var dbName = bld.InitialCatalog; //database you want to drop
            bld.InitialCatalog = "master";
            var masterConnectionString = bld.ConnectionString;
            using (var cnn = new SqlConnection(masterConnectionString))
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.Connection = cnn;
                    cnn.Open();
                    cmd.CommandText = string.Format("ALTER DATABASE {0} SET  SINGLE_USER WITH ROLLBACK IMMEDIATE",
                                  dbName);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = string.Format("DROP DATABASE {0}",
                                  dbName);
                    cmd.ExecuteNonQuery();
                }
            }             
        }
