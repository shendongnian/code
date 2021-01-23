    string I = "UPDATE client SET client.Name = ?, client.Phone = ? WHERE client.ID = ?";
    command.CommandText = I;
    command.CommandType = CommandType.Text;
    command.Parameters.AddWithValue("?", Name.Text);
    command.Parameters.AddWithValue("?", Phone.Text);
    command.Parameters.AddWithValue("?", ID.Text);
    connection.Open();
    command.ExecuteNonQuery();
