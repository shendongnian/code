    private List<string> _customers = new List<string>();
    
            public void ConnectionString()
            {
                using (var conn = new SqlCeConnection("Data Source=MyDatabase.sdf;Password=pass;Persist Security Info=True"))
                {
                    conn.Open();
                    var comm = new SqlCeCommand("SELECT * FROM main", conn);
                    SqlCeDataReader reader = comm.ExecuteReader();
    
                    string customer;
                    while (reader.Read())
                    {
                        customer = (string)(reader["CustomerName"]);
                        Console.WriteLine(customer);
                        _customers.Add(customer);
                    }
                }
            }
