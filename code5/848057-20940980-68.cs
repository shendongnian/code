    using (var connection = CreateConnection()) {
        using (var command = connection.CreateCommand()) {
            command.CommandText = "SELECT MyColumn1, MyColumn2 FROM MyTable";
            
            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    ProcessData(reader.GetString(2)); // Throws!
                }
            }
        }
    }
