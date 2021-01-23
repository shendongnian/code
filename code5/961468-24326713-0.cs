    using (dbcon)
    {
    dbcon.Open();
    cmd = dbcon.CreateCommand();
    cmd.CommandText = "Select user_name,amount from   user_table";
    
     MySqlReader  sqlreader = cmd.ExecuteReader();
    
                  while (sqlreader.Read())
                  {
                     Console.WriteLine(sqlreader[0].ToString()+ " "+(sqlreader[1].ToString());
                  }
                  sqlreader.Close();
                  
    }
