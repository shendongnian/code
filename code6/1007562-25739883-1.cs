    SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=password");
    conn.Open();
    SqlCommand command = new SqlCommand("Select id from [table1] where name=@zip", conn);
    
    //command.Parameters.AddWithValue("@zip","india");
    int result = command.ExecuteScalar();
    
    using (SqlDataReader reader = command.ExecuteReader())
    {
        // iterate your results here
        Console.WriteLine(String.Format("{0}",reader[your index]));
    }
    conn.Close();
