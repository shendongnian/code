    string sql = "INSERT into tableB(column1, column2) SELECT column1, @othervalue As column2 FROM tableA;";
    using (var connection = new SqlConnection(...))
    using (var command = new SqlCommand(sql,connection))
    {
        command.Paramters.Add("@othervalue", SqlDbType.NVarChar, 50).Value = "something";
        connection.Open();
        command.ExecuteNonQuery();
    }
