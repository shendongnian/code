    string queryString = @"SELECT userid, [password] FROM access WHERE userid = ?";
    int found = 0; //0 means not found 1 means found
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Parameters.AddWithValue("?", textBox1.Text);
        //we open the database
        connection.Open();
        //we execute the previous query
        OleDbDataReader reader = command.ExecuteReader();
