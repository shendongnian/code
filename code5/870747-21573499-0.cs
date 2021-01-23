    string queryString = "INSERT INTO registration values ('adsdsa','adsadsa',87987,'dasdsa')";
    using (OleDbConnection connection = new 
                   OleDbConnection(connection))
        {
            connection.Open();
            OleDbCommand command = new 
                OleDbCommand(queryString, connection);
            command.ExecuteNonQuery();
        }
