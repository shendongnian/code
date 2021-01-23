            public DataTable GetDataTable(string sql)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(dbConnection))
                {
                    using (SQLiteCommand mycommand = cnn.CreateCommand())
                    {
                        mycommand.CommandType = CommandType.Text;
                        mycommand.CommandText = sql;
                        using (DataTable dt = new DataTable())
                        {
                            using (SQLiteDataAdapter da = new SQLiteDataAdapter())
                            {
                                da.SelectCommand = mycommand;
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
