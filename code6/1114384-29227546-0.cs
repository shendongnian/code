    List<MySqlParameter> prms = new List<MySqlParameter>();
    StringBuilder sb = new StringBuilder();
    string query = "SELECT * FROM table";
    
    if(txtBoxStatus.Text.Trim().Length > 0)
    {
       sb.Append(" status = @status AND ");
       prms.Add("@status", MySqlDbType.VarChar).Value = txtBoxStatus.Text.Trim();
    }
    if(txtBoxAge.Text.Trim().Length > 0)
    {
       int age;
       if(Int32.TryParse(txtBoxAge.Text, out age))
       {
           sb.Append(" age = @age AND ");
           prms.Add("@age", MySqlDbType.Int).Value = age;
       }
    }
    .... so on for other parameters
    .... at the end 
    if(sb.Length > 0)
    {
        sb.Insert(0, " WHERE ");
        sb.Length -= 5; // remove the last ' AND '
    }
    MySqlCommand cmdSearch = new MySqlCommand(query + sb.ToString(), conn);
    cmdSearch.Parameters.AddRange(prms.ToArray());
    readerSearch = cmdSearch.ExecuteReader();
    ....
