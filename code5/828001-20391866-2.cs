 	string name = txtName.Text;
	var connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\chathuranga\documents\visual studio 2012\Projects\SansipProtoType\SansipProtoType\SansipDataBase.mdf;Integrated Security=True";
	var connection = new SqlConnection(ConnectionString);
    connection.Open();
	var sql = "INSERT INTO UserName VALUES (@Username)";
	using(SqlCommand command = new SqlCommand(sql, connection))
	{
		command.Parameters.AddWithValue("@Username", name);
		command.ExecuteNonQuery();
	}
	connection.Close();
    connection.Dispose();
	lblMessage.Text = "Record added successfully";
	txtName.Text = "";
