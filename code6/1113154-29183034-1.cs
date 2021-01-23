    string connectionString = ".......";
    string query = "INSERT INTO dbo.Person(birthdate) VALUES(@Birthdate);";
    using (SqlConnection con = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(query, conn))
    {
         cmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = dateTimePicker.Value.Date;
         con.Open();
         cmd.ExecuteNonQuery();
         con.Close();
    } 
