    string query = @"select WeekEnding, sum(Total) as Total 
                                            from Data  where WeekEnding = {0} 
                                             group by WeekEnding";
    string sql = String.Format(query,WeekEnding);
    //then 
    SqlCommand myCommand = new SqlCommand(sql , myConnection);
    myReader = myCommand.ExecuteReader(); 
    while (myReader.Read())
    {
        Console.WriteLine("Combined : " + myReader["Total"].ToString());
    }
