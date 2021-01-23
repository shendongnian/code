    public List<Person> LoadPeople()
    {
        var listOfPerson = new List<Person>();
        using (var connection = new SqlConnection("user id=xxx;" +
                   "password=xxx;server=xxx;" +
                   "Trusted_Connection=yes;" +
                   "database=xxx; " +
                   "connection timeout=30"))
        {
            connection.Open();
            string sql = "SELECT * FROM testTable";
            using (var command = new SqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var person = new Person();
                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.Age = Convert.ToInt32(reader["Age"]);
                        listOfPerson.Add(person);
                    }
                }
            }
        }
        return listOfPerson;
    }
