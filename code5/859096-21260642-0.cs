    public List<Staff> GetStaff(DateTime DateOne, DateTime DateTwo)
    {
        //Some connection stuff
        SqlCommand command = new SqlCommand(@"SELECT * FROM TableName 
                                              WHERE CAST(Time AS date)> @Time 
                                              and CAST(Time AS date)< @Time2", conn);
        command.Parameters.AddWithValue("Time", DateOne);
        command.Parameters.AddWithValue("Time2", DateTwo);
 
        //retrieve data
    }
