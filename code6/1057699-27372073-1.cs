                    string sql = @"
                    SELECT 
                        Person.Id AS PersonId, 
                        Person.Name AS PersonName, 
                        Hobby.Id AS HobbyId,
                        Hobby.Name AS HobbyName,
                        Color.Id AS ColorId,
                        Color.Name AS ColorName
                    FROM Person
                    INNER JOIN Color on Person.Id = Color.PersonId
                    INNER JOIN Hobby on Person.Id = Hobby.PersonId
                    Order By PersonId"; // Order By is required to get the person data sorted as per the person id
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        List<Person> persons = new List<Person>();
                        while (reader.Read())
                        {
                            var personId = reader.GetInt32(0);
                            var personName = reader.GetString(1);
                            var hobbyId = reader.GetInt32(3);
                            var hobbyName = reader.GetString(4);
                            var colorId = reader.GetInt32(5);
                            var colorName = reader.GetString(6);
                            var person = persons.Where(p => p.Id == personId).FirstOrDefault();
                            if (person == null)
                            {
                                person = new Person();
                                person.Id = personId;
                                person.Name = personName;
                                hobby = new Hobby() { Id = hobbyId, Name = hobbyName };
                                color = new Color() { Id = colorId, Name = colorName };
                                
                                person.FavoriteColors = new List<Color>();
                                person.Hobbies = new List<Hobby>();
                                person.FavoriteColors.Add(color);
                                person.Hobbies.Add(hobby);
                                persons.Add(person);
                            }
                            else
                            {
                                hobby = new Hobby() { Id = hobbyId, Name = hobbyName };
                                color = new Color() { Id = colorId, Name = colorName };
                                person.FavoriteColors.Add(color);
                                person.Hobbies.Add(hobby);
                            }
                        }
                    }
                }
            }
