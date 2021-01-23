    var query = "SELECT title, locked FROM some_table;"
    using (var cmd = new SqlCommand(someConnection, query))
    {
        ...  // open the connection, run the query, assign the results to yourReader
        while (yourReader.Read())
        {
            var title = (string)yourReader.GetValue(0);
            var locked = (int)yourReader.GetValue(1);
            // do something with title and locked
        }
    }
