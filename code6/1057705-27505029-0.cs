    		public static IEnumerable<Person> DataFetcher(string connString)
		{
			Dictionary<int, Person> personDict = new Dictionary<int,Person>(1024);	//1024 was arbitrarily chosen to reduce the number of resizing operations on the underlying arrays; 
																					//we can rather issue a count first to get the number of rows that will be returned (probably divided by 2).
			using (SqlConnection conn = new SqlConnection(connString))
			{
				string sql = @"
                    SELECT 
                        Person.Id AS PersonId, 
                        Person.Name AS PersonName, 
                        Hobby.Id AS HobbyId,
                        Hobby.Name AS HobbyName,
                        Color.Id AS ColorId,
                        Color.Name AS ColorName
                    FROM Person
                    LEFT JOIN Color on Person.Id = Color.PersonId
                    LEFT JOIN Hobby on Person.Id = Hobby.PersonId";
				using (SqlCommand comm = new SqlCommand(sql, conn))
				{
					using (SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (reader.Read())
						{
							int personId = reader.GetInt32(0);
							string personName = reader.GetString(1);
							object hobbyIdObject = reader.GetValue(2);
							object hobbyNameObject = reader.GetValue(3);
							object colorIdObject = reader.GetValue(4);
							object colorNameObject = reader.GetValue(5);
							Person person;
							personDict.TryGetValue(personId, out person);
							if (person == null)
							{
								person = new Person
								{
									Id = personId,
									Name = personName,
									FavoriteColors = new List<Color>(),
									Hobbies = new List<Hobby>()
								};
								personDict[personId] = person;
							}
							if (!Convert.IsDBNull(hobbyIdObject))
							{
								int hobbyId = Convert.ToInt32(hobbyIdObject);
								Hobby hobby = person.Hobbies.FirstOrDefault(ent => ent.Id == hobbyId);
								if (hobby == null)
								{
									hobby = new Hobby
									{
										Id = hobbyId,
										Name = hobbyNameObject.ToString()
									};
									person.Hobbies.Add(hobby);
								}
							}
							if (!Convert.IsDBNull(colorIdObject))
							{
								int colorId = Convert.ToInt32(colorIdObject);
								Color color = person.FavoriteColors.FirstOrDefault(ent => ent.Id == colorId);
								if (color == null)
								{
									color = new Color
									{
										Id = colorId,
										Name = colorNameObject.ToString()
									};
									person.FavoriteColors.Add(color);
								}
							}
						}
					}
				}
			}
			return personDict.Values;
		}
