    var databases = new List<string>();
    var excludedDatabases =
        new List<string> { "information_schema", "sakila", "enrollmentsystem",
                           "mysql", "world", "performance_schema" };
    while (reader.Read())
    {
        var database = reader["Database"].ToString();
        if (!excludedDatabases.Contains(database))
            databases.Add(database);
    }
