        private System.Object syncLock = new System.Object();
        public int ExecuteNonQueryWithBlob(string sql, string blobFieldName, byte[] blob)
        {
            lock (syncLock)
            {
                try
                {
                    using (var c = new SQLiteConnection(dbConnection))
                    {
                        using (var cmd = new SQLiteCommand(sql, c))
                        {
                            cmd.Connection.Open();
                            cmd.Parameters.AddWithValue("@" + blobFieldName, blob);
                            return cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
        }
		
        public DataTable GetDataTable(string sql)
        {
            lock (syncLock)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (var c = new SQLiteConnection(dbConnection))
                    {
                        c.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                        {
                            using (SQLiteDataReader rdr = cmd.ExecuteReader())
                            {
                                dt.Load(rdr);
                                return dt;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
 
