    String conn = @"Data Source=myserverName;
           Initial Catalog=myCatalogName;Integrated Security=True";
    string cmdStr = "select count(*) from 
          information_schema.views where table_schema = 'mySchemaName' 
          AND table_name = 'MyViewName'";
    
    using (MySqlConnection conn = new MySqlConnection(connStr))
    {
        MySqlCommand cmd = new MySqlCommand(cmdStr, conn);
        conn.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
           int count = reader.GetInt32(0);
           if (count == 0)
           {
               MessageBox.Show("View does not exists!");
           }
           else if (count == 1)
           {
               MessageBox.Show("View exists!");
           }
        }
    }
