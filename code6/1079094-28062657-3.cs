    public static void DB_Select(string s, params List<string>[] lists)
    {
        try
        {
             using(var conn = new MySqlConnection(Services.ServerConnection))
             {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = s;
                using( var sqlreader = cmd.ExecuteReader())
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
                } // unnecessary to close the connection
            }     // or the reader with the using-stetement
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error while selecting data from database!\nDetails: " + ex);
        }
    }
