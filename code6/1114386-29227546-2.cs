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
    ....
    .... and at the end 
    MySqlCommand cmdSearch = new MySqlCommand(query + sb.ToString(), conn);
    if(sb.Length > 0)
    {
        // If you enter here you have one or more WHERE conditions 
        // AND a list of parameters to add to the query
        sb.Insert(0, " WHERE ");
        sb.Length -= 5; // remove the last ' AND '
        cmdSearch.Parameters.AddRange(prms.ToArray());
    }
    readerSearch = cmdSearch.ExecuteReader();
    ....
