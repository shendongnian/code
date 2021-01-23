    try
                {
                    CardConn.Open();
                    SqlCeCommand insertCommand = new SqlCeCommand("INSERT INTO Data VALUES(@Name, @Pack, @Value, @Color, @Description)", CardConn);
                    insertCommand.Parameters.Add("Name", c.Name);
                    insertCommand.Parameters.Add("Pack", c.Pack);
                    insertCommand.Parameters.Add("Value", c.Value);
                    insertCommand.Parameters.Add("Color", c.Color);
                    insertCommand.Parameters.Add("Description", c.Description);
                    Console.WriteLine("Card inserted successfully");
                }
