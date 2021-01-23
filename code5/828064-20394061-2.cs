    string connString = "Server=localhost;port3306;Database=program;Uid=joffe;Pwd=hej123;";
    var sql = "SELECT * FROM tabell";
    using(var connection = new MySqlConnection(connString))
    {
    	connection.Open();
    	using (var command = new MySqlCommand(sql, connection))
    	{
    		var reader = command.ExecuteReader();
    		while (reader.Read()) Console.WriteLine((string)reader["Nick"]);
    	}
    	connection.Close();
    }
