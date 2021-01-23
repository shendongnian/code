      SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=");
        conn.Open();
        SqlCommand command = new SqlCommand("Select id from [table1] where name=@zip", conn);
        command.Parameters.AddWithValue("@zip","india");
        int result = (int)command.ExecuteScalar();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            Console.WriteLine(String.Format("{0}",reader["id"]));
        }
        conn.Close();
