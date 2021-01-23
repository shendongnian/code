	using (var version = new SqlCommand())
	{
		version.CommandType = CommandType.Text;
		version.Connection = cnn;
		
		cnn.Open();
		version.CommandText = sqlCom1;
		label.Text = (string)version.ExecuteScalar();
		
		version.CommandText = sqlCom2;
		label2.Text = (string)version.ExecuteScalar();
		cnn.Close();
	};
