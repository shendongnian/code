    using (var connection = new OracleConnection(...)
    {
        connection.Open();
        string sql = "insert into banks_ben_branch_99 [... as before ...]";
        using (var command = new OracleCommand(sql, conn))
        {
            command.Parameters.Add("user_id", OracleType.VarChar, 20)
                              .Value = textBox1.Text;
            command.ExecuteNonQuery();
        }
    }
