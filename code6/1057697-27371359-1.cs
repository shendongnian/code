    ...
    var persons = new List<Person>();
    while (reader.Read())
    {
        var person = new Person();
        Person.Id = reader.GetInt32(0);
        ... // populate the other Person properties as required
        
        // Get list of hobbies for this person
        // Use a query to get hobbies for this person id
        // e.g. "SELECT * FROM Hobby WHERE Hobby.PersonId = " + Person.Id
        // Get a list of colours
        // Use a query to get colours for this person id
    }
