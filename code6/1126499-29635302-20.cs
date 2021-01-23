    var command = new OleDbCommand("UPDATE Users SET first_name = ? WHERE ID = ?");
    command.Parameters.AddWithValue("id", Session["ColumnID"].ToString());
    command.Parameters.AddWithValue("firstname", txt_firstname.Text);
    using (var connection = new OleDbConnection(connectionString))
    {
        command.Connection = connection;
        connection.Open();
        command.ExecuteNonQuery();
    }
