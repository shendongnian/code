    if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int result = Convert.ToInt32(reader.GetString(0)); 
                        Console.WriteLine(result);
                    }
                }
