    public Tuple<int,string,string> GetAdditionalData(List<IPersonData> people)
    {
        string peopleIds = String.Join( ",", people.Select(x => x.ID));
        using (var conn = Database.GetConnection(Database.PeopleDB))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "spGetPeopleData" ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.AddParameterWithValue( "@Ids" , peopleIds);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Tuple<int,string,string>(
                            reader["PersonId" ],
                            reader["HairColor" ],
                            reader["EyeColor" ]);
                    }
                }
            }
        }
    }
    public void Enrich(List<IPersonData> people)
    {
        var dataToEnrich = from person in people
                           join additional in GetAdditionalData(people)
                               on additional.Item1 equals person.ID
                           select new { Person = person, 
                                        HairColor = additional.Item2, 
                                        EyeColor = additional.Item3 };
       
        foreach(var enrichment in dataToEnrich)
        {
            enrichment.Person.HairColor = enrichment.HairColor;
            enrichment.Person.EyeColor = enrichment.EyeColor ;
        }
    }
