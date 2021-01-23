    var command = new SqlCommand("UPDATE Users SET first_name = @firstname WHERE ID = @id");
    command.Parameters.AddWithValue("id", Session["ColumnID"].ToString());
    command.Parameters.AddWithValue("firstname", txt_firstname.Text);
    using (var connection = new SqlConnection(connectionString))
    {
        command.Connection = connection;
        connection.Open();
        command.ExecuteNonQuery();
    }
