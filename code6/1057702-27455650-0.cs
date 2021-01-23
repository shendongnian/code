    using (SqlConnection connection = new SqlConnection("connection string here"))
            {
                using (SqlCommand command = new SqlCommand
                       ("SELECT Id, Name FROM Person WHERE Id=1; SELECT Id, Name FROM FavoriteColors WHERE PersonId=1;SELECT Id, Name FROM Hobbies WHERE PersonId=1", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Person p = new Person();
                        while (reader.Read())
                        {
                            p.Id = reader.GetInteger(0);
                            p.Name = reader.GetString(1);
                        }
    
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var clr = new Color();
                                clr.Id = reader.GetInteger(0);
                                clr.Name = reader.GetString(1);
                                p.FavoriteColors.Add(clr);
                            }
                        }
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var hby = new Hobby();
                                hby.Id = reader.GetInteger(0);
                                hby.Name = reader.GetString(1);
                                p.Hobbies.Add(clr);
                            }
                        }
                    }
                }
            }
