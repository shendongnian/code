    // @transfer_date is now a *parameter*.
    string sql = "insert into MyTbl (DateT) values (@transfer_date)";
    // Avoid using a shared connection - it'll cause problems. Let the connection
    // pooling do its job. But use using statements to ensure that both the connection
    // and the statement are disposed.
    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(sql, connection))
        {
            // No need to set the CommandText value now - it's already set up above.
            // But we need to set the value of the parameter.
            command.Parameters.Add("@transfer_date", SqlDbType.SmallDateTime).Value
                 = DateTime.Now;
            command.ExecuteNonQuery();
        }
    }
