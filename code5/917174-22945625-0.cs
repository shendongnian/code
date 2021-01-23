    using (var cnx = new SqlConnection(connectionString)) {
        cnx.Open();
        var cmd = cnx.CreateCommand();
        cmd.CommandText = sql; // sql is actually your string containing named-parameters
        var param1 = cmd.CreateParameter();
        param1.DbType = DbType.Int32;
        param1.ParameterDirection = ParameterDirection.Input;
        param1.Name = "@p0";
        param1.Value = value;
        cmd.ExecuteQuery(); // Make sure to use proper method call here.
    }
