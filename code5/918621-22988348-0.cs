        static class MySQLConnect
        {
                private static SqlConnection _Connection;
                public static SqlConnection Connection
                {
                        get
                        {
                                if(_Connection == null)
                                {
                                        string cs = @"server=127.0.0.1; user id=root; password=''; database=cluster";
                                        _Connection = new MySqlConnection(cs);
                                }
                                if(_Connection.State == ConnectionState.Closed)
                                        try
                                        {
                                                    conn.Open();
                                        }
                                        catch(Exception ex)
                                        {
                                                //handle your exception here
                                        }
                                return _Connection;
                        }
                }
        }
