    const string updateTable = "UPDATE [dbo].[Tablename]
        SET [Date] = getutcdate()
        WHERE [Name] = @Name;"
    using (var connection = new SqlConnection(youConnectionString))
    {
        using(var command = new SqlCommand(updateTable, connection))
        {
            command.Parameters.AddWithValue("@Name", TextBox1.Text);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    
