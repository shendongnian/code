    string sql = "INSERT INTO TABLE Person (ID, NAME) VALUES (@id, @name)";
    using (var command = new MySqlCommand(sql, conn))
    {
        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = txtCode.Text;
        command.ExecuteNonQuery();
    }
