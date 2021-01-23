    string query = "SELECT firstname, lastname FROM users";
    Statement stQuery = SQLite3.Prepare2(connection.Handle, query);
    while ((SQLite3.Result result = SQLite3.Step(stQuery)) == SQLite3.Result.Row)
    {
    //your stuff here
    }
    SQLite3.Finalize(stQuery);
