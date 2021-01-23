    using(MySqlConnection Connection = new MySqlConnection("SERVER=localhost;UID=root;"))
    using(MySqlCommand Command = new MySqlCommand("CREATE USER 'testuser'@'localhost' IDENTIFIED BY 'superpassword';", Connection))
    {
        Connection.Open();
        Command.ExecuteNonQuery();
    }
