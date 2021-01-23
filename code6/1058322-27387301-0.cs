	using (var cs = new SqlConnection("your connection string"))
	{
        cs.Open();
		using (var command = cs.CreateCommand())
		{
			command.CommandText = 
                @"SELECT 
                      time_in, 
                      time_out, 
                      DATEDIFF(minute, time_in, time_out) As minutesWorked 
                  FROM job_punch_card  
                  WHERE emp_key=@EMPKEY 
                        and punch_day= DATEADD(week, DATEDIFF(day, 0, getdate())/7, 2)";
			command.Parameters.AddWithValue(
                "@EMPKEY", 
                listBoxNames.SelectedValue.ToString());
			using (var reader = command.ExecuteReader())
			{
				if (!reader.HasRows)
				{
					// There was no match for your key
				}
				reader.Read();
				DateTime timeIn = reader.GetDateTime(0);
				DateTime timeOut = reader.GetDateTime(1);
				int minutesWorked = reader.GetInt32(2);
				if (reader.Read())
				{
					// There was more than one match on key
				}
			}
		}
	}
