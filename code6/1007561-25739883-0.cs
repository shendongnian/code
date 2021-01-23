    SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=");
    conn.Open();
    SqlCommand command = new SqlCommand("Select id from [table1] where name=@zip", conn);
    
    //command.Parameters.AddWithValue("@zip","india");
    int result = command.ExecuteScalar();
    // result gives the -1 output.. but on insert its 1
    using (SqlDataReader reader = command.ExecuteReader())
    {
        // iterate your results here
        Console.WriteLine(String.Format("{0}",reader["id"]));
    }
    conn.Close();
