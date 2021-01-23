       public static MySqlConnection conn // Returns the connection itself
           {
                get
                {
                    MySqlConnection conn = new MySqlConnection(Services.ServerConnection);
                    return conn;
                }
            }
    
        private static string ServerConnection // Returns the connectin-string - PRIVATE [Improved security]
            {
                get
                {    
                    return String.Format("Server={0};Port=XXXX;Database=xxx;Uid=xxx;password=xxXxxXxXxxXxxXX;", key);
                }
            }
    
     // Rather than executing result here, return the result to LoginForm - Future improvement
      public static void DB_Select(MySqlConnection conn ,string s, params List<string>[] lists)
            {
                try
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    string command = s;
                    cmd.CommandText = command;
                    MySqlDataReader sqlreader = cmd.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        if (sqlreader[0].ToString().Length > 0)
                        {
                            for (int i = 0; i < lists.Count(); i++)
                            {
                                lists[i].Add(sqlreader[i].ToString());
                            }
                        }
                        else
                        {
                            foreach (List<string> save in lists)
                            {
                                save.Add("/");
                            }
                        }
                    }
                    sqlreader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while selecting data from database!\nDetails: " + ex);
                }
            }
