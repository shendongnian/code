        public string getTop10()
        {
            List<string> Toplist = new List<string>();
            string connection = "YourConnectionString";
            using (var con = new SQLiteConnection { ConnectionString = connection })
            {
                using (var command = new SQLiteCommand { Connection = con })
                {
                    con.Open();
                    command.CommandText = @"SELECT user FROM @channel ORDER BY currency DESC LIMIT 10";
                    command.Parameters.AddWithValue("@channel", channel);
                    using (var r = command.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            Toplist.Add(r.GetString(0));
                        }
                        
                    }
                }
                
            }
            return string.Join(",", Toplist);
        }
