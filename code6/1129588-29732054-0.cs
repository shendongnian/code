        SqlCommand command6 = new SqlCommand("SELECT ([QuestionID]) FROM Questions", connect);
        
        String s = "";
		using (SqlDataReader reader = command6.ExecuteReader())
		{
		    while (reader.Read())
		    {
			for (int i = 0; i < reader.FieldCount; i++)
			{
			    s += (reader.GetValue(i));
			}
		    }
		}
        QuestionNum.Text = s;
