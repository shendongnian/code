    MySqlConnection connection = new MySqlConnection(MyConString);
    connection.Open();
    ...
    MySqlCommand SQLup = new MySqlCommand(mySQL, connection);
    SQLup.ExecuteNonQuery();
