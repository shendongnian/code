    using (MySqlConnection myConnection = new MySqlConnection("ConnString"))
    {
        foreach (var item in input)
        {                  
            using (MySqlCommand myCommand = new MySqlCommand("spInputData", myConnection))
            {
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@Parameter1", item.a);
                myCommand.Parameters.Add("@Parameter2", item.b);
                myCommand.ExecuteNonQuery();
            }
        }
    }
