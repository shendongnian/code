    using(OleDbConnection connection = new OleDbConnection(conString))
    using(OleDbCommand command = _connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO Customers(CustomerID, CompanyName) VALUES(?, ?)";
        command.Parameters.Add("@p1", OleDbType.Integer).Value = qqq;
        command.Parameters.Add("@p2", OleDbType.VarChar).Value = xyz;
        // I assume your column types as Integer and VarChar
        connection.Open();
        command.ExecuteNonQuery();
    }
