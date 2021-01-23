    const string commandText = "INSERT INTO [Table] (id,name) VALUES (1,@Name)";
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@Name", SqlDbType.VarChar);
        command.Parameters["@Name"].Value = textBox1.Text;
        connection.Open();
        var rowsAffected = command.ExecuteNonQuery();
    }
