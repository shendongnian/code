    var listOfPerson = new List<Person>();
    while (reader.Read())
    {
        var person = new Person();
        person.FirstName = reader["FirstName"].ToString();
        person.LastName = reader["LastName"].ToString();
        person.Age = Convert.ToInt32(reader["Age"]);
        listOfPerson.Add(person);
    }
    return listOfPerson;
