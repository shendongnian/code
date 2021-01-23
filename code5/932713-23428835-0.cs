    var sql = "UPDATE tbl SET [downloaded] = 0 WHERE name = @name";
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.AddWithValue("@name", originalFileName);
        command.ExecuteNonQuery();
    }
