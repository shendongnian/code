    try
                {
                    CardConn.Open();
                    SqlCeCommand insertCommand = new SqlCeCommand("INSERT INTO Data VALUES(@Name, @Pack, @Value, @Color, @Description)", CardConn);
                    insertCommand.Parameters.Add("Name", c.Name);
                    insertCommand.Parameters.Add("Pack", c.Pack);
                    insertCommand.Parameters.Add("Value", (int)c.Value);
                    insertCommand.Parameters.Add("Color", (int)c.Color);
                    insertCommand.Parameters.Add("Description", c.Description);
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Card inserted successfully");
                }
