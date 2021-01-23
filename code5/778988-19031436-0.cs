    DateTime WeekEnding = new DateTime(2013, 9, 22);
    SqlDataReader myReader = null;
    SqlCommand myCommand = new SqlCommand(
        @"select WeekEnding, sum(Total) as Total " +
         "from Data  where WeekEnding >= @WeekEnding AND WeekEnding <= @WeekEnding" +
         "group by WeekEnding", 
         myConnection);
    myCommand.Parameters.Add("@WeekEnding", SqlDbType.DateTime);
    myCommand.Parameters["@WeekEnding"].Value = WeekEnding;
    myReader = myCommand.ExecuteReader();
    
    while (myReader.Read())
    {
        Console.WriteLine("Combined : " + myReader["Total"].ToString());
    }
