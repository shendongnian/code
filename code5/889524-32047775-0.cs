     static DataTable  GetDataFromHive()
            {
                OdbcConnection DbConnection = new OdbcConnection("DSN=horton");
                try
                {
                    DbConnection.Open();
                }
                catch (OdbcException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                OdbcCommand cmd = DbConnection.CreateCommand();
                cmd.CommandText = "SELECT * FROM sample_08 LIMIT 100;";
                DbDataReader dr = cmd.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(dr);
                DbConnection.Close();
                return dataTable;
            }
