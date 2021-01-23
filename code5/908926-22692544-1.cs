    List<string> returnedList = new List<string>();
    using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT something FROM table"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnedList.Add(Convert.ToString(reader["something"]));
                }
            }
        }
    }
