    string query = "YOUR_QUERY_HERE";
    using (SqlConnection connection = new SqlConnection("Data Source=PCM13812;Initial Catalog=Kronhjorten;Integrated Security=True"))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open(); 
            command.ExecuteNonQuery();
        }
    }
