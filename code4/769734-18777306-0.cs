    string sql = "INSERT into tableB(column1) SELECT column1 FROM tableA;";
    using (var connection = new SqlConnection(...))
    using (var command = new SqlCommand(sql,connection))
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
