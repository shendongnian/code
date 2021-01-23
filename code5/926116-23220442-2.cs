    String conn = @"Data Source=myserverName;
           Initial Catalog=myCatalogName;Integrated Security=True";
    string cmdStr = "select count(*) from 
          information_schema.views where table_schema = 'mySchemaName' 
          AND table_name = 'MyViewName'";
    
    using (MySqlConnection conn = new MySqlConnection(conn))
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
	             MySqlCommand command = new MySqlCommand("Create View myView
                 as select
                 * from myTable;", conn)
               command.ExecuteNonQuery();
              
           }
           else if (count == 1)
           {
               MessageBox.Show("View exists!");
           }
            conn.Close();
        }
    }
