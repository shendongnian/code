    SqlCommand command = new SqlCommand(@"SELECT ID, Name , Status FROM Client
                                          WHERE status = @st;",connection);    
    command.Parameters.AddWithValue("@st", "N");  // Or use a passed string variable
    connection.Open();
    SqlDataReader reader = command.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            // Here you have only the records with status = "N"
        }
    }
