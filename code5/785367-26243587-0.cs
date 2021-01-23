    private string TestConnectionEF()
            {
                using (var db = new SistemaContext())
                {
                    try
                    {
                        db.Database.Connection.Open();
                        if (db.Database.Connection.State == ConnectionState.Open)
                        {
                            Console.WriteLine(@"INFO: ConnectionString: " + db.Database.Connection.ConnectionString 
                                + "\n DataBase: " + db.Database.Connection.Database 
                                + "\n DataSource: " + db.Database.Connection.DataSource 
                                + "\n ServerVersion: " + db.Database.Connection.ServerVersion 
                                + "\n TimeOut: " + db.Database.Connection.ConnectionTimeout);
                            db.Database.Connection.Close();
                            return null;
                        }
                        return "ERROR";
                    }
                    catch(Exception ex)
                    {
                        return ex.Message + " \n PING: " + TryPing(db.Database.Connection.DataSource).ToString();
                    }
                }
            }
