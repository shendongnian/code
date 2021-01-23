    using(OleDbConnection connection = new OleDbConnection(conString))
    using(OleDbCommand command = _connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO Customers(CustomerID, CompanyName) VALUES(?, ?)";
        command.Parameters.Add("@p1", OleDbType.VarChar).Value = qqq;
        command.Parameters.Add("@p2", OleDbType.VarChar).Value = xyz;
        connection.Open();
        command.ExecuteNonQuery();
    }
