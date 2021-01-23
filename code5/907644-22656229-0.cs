    using (SqlConnection connection = new SqlConnection("yourConnectionString"))
    {
        connection.Open();
        SqlCommand command = new SqlCommand("select bhand from importdb where bhand = 3 and store = 14", connection);
        SqlDataReader reader = command.ExecuteReader();
        SqlConnection connection2 = new SqlConnection("yourConnectionStringTo2ndDB");
        connection2.Open();
        while (reader.Read())
        {
            SqlCommand command = new SqlCommand("insert into importabd ('bhand') values ('" +  reader[0]+"')", connection2);
            command.ExecuteNonQuery();
        }
        connection2.close();
    }
