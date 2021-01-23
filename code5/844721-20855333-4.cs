    public class ADOPeopleRepository: IPeopleRepository
    {
        public IEnumerable<Person> Get()
        {
            string connectionString = ...;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT id, name, age, dob FROM people";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Person
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Age = reader.GetInt32(reader.GetOrdinal("age")),
                            Dob = reader.GetDateTime(reader.GetOrdinal("dob")),
                        };
                    }
                }
            }
        }
    
        ...
    }
