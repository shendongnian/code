    string queryString = "INSERT INTO registration values ('adsdsa','adsadsa',87987,'dasdsa')";
    using (OleDbConnection connection = new OleDbConnection(connection))
    using (OleDbCommand command = new OleDbCommand(queryString, connection))
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
