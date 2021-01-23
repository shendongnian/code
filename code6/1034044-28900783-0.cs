    private void BindGrid()
    {
      string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlServer"].ConnectionString;
 
       using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("getaudio", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (IDataReader idr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = idr;
                    GridView1.DataBind();
                }
                conn.Close();               
            }
         }
    }
