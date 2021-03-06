        private static void ReadGetOrdinal(string connectionString)
        {
            string queryString = "SELECT DISTINCT CustomerID FROM dbo.Orders;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
    
                        // Call GetOrdinal and assign value to variable. 
                        int customerID = reader.GetOrdinal("CustomerID");
    
                        // Use variable with GetString inside of loop. 
                        while (reader.Read())
                        {
                            Console.WriteLine("CustomerID={0}", reader.GetString(customerID));
                        }
                    }
                }
            }
        }
