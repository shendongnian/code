        int count = 0;
        using(SQLiteConnection con = new SQLiteConnection(cs))
        {
            con.Open();
            string stm = "select count(id) as count from tblActivities WHERE [Activity] = 'Sleeping'";
            using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
            {
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["count"] != DBNull.Value && reader["count"] != null)
                        {
                            if (!int.TryParse(reader["count"], out count))
                            {
                                //failed to parse
                            }
                        }
                     }
                }
            }
            con.Close();   
         }
