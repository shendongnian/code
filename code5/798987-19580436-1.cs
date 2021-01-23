    private static DataTable GetData(string query)
    {
        string strConnString = "SERVER=localhost;DATABASE=database;UID=root;PASSWORD=123456789;";
        using (MySqlConnection con = new MySqlConnection(strConnString))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
