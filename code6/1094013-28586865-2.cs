    var persons = new List<Person>();
    using (SqlConnection connection = new SqlConnection(connectionString)) {
        string sqlText = "Select p.PersonId, ps.Name, ps.StatusId" FROM Person p INNER JOIN PersonStatus ps on p.StatusID = ps.StatusId WHERE p.PersonId = @personId";
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@personId", SqlDbType.Int);
        command.Parameters["@personId"].Value = personId;
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) 
            {
                var person = new Person();
                var status = new PersonStatus();
                person.PersonID = reader["PersonId"]; 
                status.StatusId = reader["StatusId"];
                status.Name = reader["Name"];
                person.Status = status;
                persons.Add(person);
            }
        }
    }
    return persons;
