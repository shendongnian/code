    public IEnumerable<Customer> GetCustomers()
    {
        using (var connection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["conn"].ConnectionString));
        {
            using (var command = new SqlCommand
                    {
                        CommandText = 
                            "SELECT " +
                                "cust_id, " +
                                "cust_code, " +
                                "cust_name, " +
                                "cust_descr, " +
                                "created_dt " +
                                " FROM customer",
                        Connection = connection
                    })
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Customer
                        {
                            CustId = reader.GetInt32(0),
                            CustCode = reader.GetString(1),
                            CustName = reader.GetString(2),
                            CustDescr = reader.GetString(3),
                            CreatedDt = reader.GetDateTime(4)
                        };
                    }
                }
            }
        }
    }
