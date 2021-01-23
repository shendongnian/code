    string name = this.nameTextBox.Text;
    string phone = this.phoneTextBox.Text;
    if (string.IsNullOrWhiteSpace(name))
        name = null;
    if (string.IsNullOrWhiteSpace(phone))
        phone = null;
    SqlConnection connection = new SqlConnection(@"<connection string>");
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandType = CommandType.StoredProcedure;
        // leave this as the stored procedure name only
        command.CommandText = "spFoo";
        // if name is null, then Jim gets passed (see stored procedure definition)
        // if phone is null, then null gets passed (see stored procedure definition)
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@phone", phone);
        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
