    using (var connection = new SqlConnection("<your connection string>"))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO (sometable) VALUES (@somedatecolumn)";
        command.CommandType = CommandType.Text;
        var parameter = new SqlParameter("@somedatecolumn", SqlDbType.SmallDateTime);
        parameter.Value = <your date/time value>; // a DateTime value, not a string
        command.Parameters.Add(parameter);
        command.ExecuteNonQuery();
    }
