    // Obviously fill in the "..." with the rest of the fields you need to use
    string sql = "INSERT INTO ProjectMaster (ProjectCode, TransactionType, ...) "
               + "VALUES (@ProjectCode, @TransactionType, ...)";
    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
            // Check the parameter types! We don't know what they're meant to be
            command.Parameters.Add("@ProjectCode", SqlType.NVarChar).Value = ...;
            command.Parameters.Add("@TransactionType", SqlType.NVarChar).Value = ...;
            ...
            command.ExecuteNonQuery();
        }
    }
