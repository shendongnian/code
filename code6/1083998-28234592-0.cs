    using (SqlCommand command = new SqlCommand(
      "SELECT * FROM ["+TableName+"] WHERE convert(varchar,["Date"],112) like @Date", connection))
    {
        command.Parameters.Add(new SqlParameter("Date", filterFunc().Trim() + "%"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string val1 = reader.GetString(0);
            string val2 = reader.GetString(1);
            Console.WriteLine("Val 1= {0}, Val2 = {1}", val1, val2);
        }
    }
