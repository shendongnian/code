    public String[] ReturnCustomers(string sqlQuery, int size)
    {
        createConnectionString();
        StreamWriter file = new StreamWriter("dbCustomerList");
        List<string> results = new List<string>();
        using (SqlConnection myConnection = new SqlConnection(_ConnectionString))
        {
            myConnection.Open();
            using(SqlCommand cmd = new SqlCommand(sqlQuery, myConnection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                  while (reader.Read())
                  {
                    Console.WriteLine(reader.GetString(0));
                    results.Add(reader.GetString(0));
                  }     
                }
            }
            myConnection.Close();
        }
        return results.ToArray();
    }
