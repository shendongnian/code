    using (System.Data.OleDb.OleDbConnection oledbConnection = new System.Data.OleDb.OleDbConnection(ConnectionString))
                {
                    oledbConnection.Open();
                    using (System.Data.OleDb.OleDbCommand getData = new System.Data.OleDb.OleDbCommand())
                    {
                        getData.CommandText = "select * from table ";
                        getData.Connection = oledbConnection;
                        using (System.Data.OleDb.OleDbDataReader readData = getData.ExecuteReader())
                        {
                            if (readData.HasRows)
                            {
                                while (readData.Read())
                                {
                                  // get the data here
                                }
                            }
                        
                        }
                    }
