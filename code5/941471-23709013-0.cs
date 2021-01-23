    string sql = "SELECT FOO FROM BAR WHERE X=@X";
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.Add("@X", SqlDbType.NVarChar).Value = "...";
        using (var reader = command.ExecuteReader())
        {
            ...
        }
    }
