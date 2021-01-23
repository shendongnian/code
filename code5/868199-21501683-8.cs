     string myConnectionString;
            myConnectionString =
                    @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data Source=C:\Users\Public\Database1.accdb;";
            using (var con = new OleDbConnection())
            {
                con.ConnectionString = myConnectionString;
                con.Open();
                using (var cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText =
                        @"INSERT INTO YourTable (Column1, Column2) VALUES ('Hello', 'World')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
