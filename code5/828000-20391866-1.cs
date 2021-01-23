 	string name = txtName.Text;
	string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\chathuranga\documents\visual studio 2012\Projects\SansipProtoType\SansipProtoType\SansipDataBase.mdf;Integrated Security=True";
	SqlConnection con = new SqlConnection(ConnectionString);
    con.Open();
	String sql = "INSERT INTO UserName VALUES (@Username)";
	using(SqlCommand com = new SqlCommand(sql, con))
	{
		com.Parameters.AddWithValue("@Username", name);
		com.ExecuteNonQuery();
	}
	con.Close();
    con.Dispose();
	lblMessage.Text = "Record added successfully";
	txtName.Text = "";
