    using(OleDbConnection con = new OleDbConnection(conString))
    using(OleDbCommand command = con.CreateCommand())
    {
        command.CommandText = "UPDATE CustomersTable SET CompanyName = ? WHERE CompanyName = ?";
        command.Parameters.Add("@p1", OleDbType.VarChar).Value = "xyz3";
        command.Parameters.Add("@p2", OleDbType.VarChar).Value = "xyz4";
        con.Open();
        command.ExecuteNonQuery();
    }
