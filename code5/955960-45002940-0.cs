    using (var con = new MySqlConnection { ConnectionString = "YourConnectionString" })
            {
                con.Open();
                MySqlTransaction trans = con.BeginTransaction();
                MySqlCommand command = con.CreateCommand();
                try
                {
                    command.CommandText = @"LOCK TABLES table_1 WRITE, table_2 WRITE;
                                            INSERT INTO table_1 VALUES ('val1', 'val2');
                                            INSERT INTO table_2 VALUES ('val1', 'val2');
                                            UNLOCK TABLES;";
                    command.ExecuteNonQuery();
                    trans.Commit();
                }
                catch(MySqlException ex)
                {
                    trans.Rollback();
                    conn.msgErr(ex.Message + " sql query error.");
                    conn.msgErr("Neither record was written to database.");
                }
                finally
                {
                    command.Dispose();
                    trans.Dispose();
                }
                
            }
 
