     SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=");
          conn.Open();
          SqlCommand command = new SqlCommand("Select id from [table1] where name=@zip", conn);
		  //
		// Add new SqlParameter to the command.
		//
          command.Parameters.AddWithValue("@zip","india");
		  int result = (Int32) (command.ExecuteScalar());
          using (SqlDataReader reader = command.ExecuteReader())
          {
              // iterate your results here
           Console.WriteLine(String.Format("{0}",reader["id"]));
          }
          conn.Close();
