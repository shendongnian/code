    	myCommand.CommandText = "SELECT GB,Form_Factor FROM devices WHERE Serial_Number = @Sn";
	myCommand.Parameters.AddWithValue("@Sn", Sn);
	connect.Open();
	MySqlDataReader reader = myCommand.ExecuteReader();
	if (reader.Read())
	{
	    textBox2.Text = reader["GB"].ToString();
	    textBox3.Text = reader["Form_Factor"].ToString();
	}
	reader.Close();
	connect.Close();
	string gb = textBox2.Text;
	string ff = textBox3.Text;
	myCOmmand.CommandText = @"SELECT * FROM parameters WHERE Form_Factor = 'Mercury';";
	connect.Open();
	MySqlDataReader reader2 = myCommand.ExecuteReader();
	reader2.Read();
	if (reader2.Read())
	{
	    string command = reader2["columnName"].ToString();
	   	MessageBox.Show(command);
	}
	if (reader2.Read() == false)
	{
	    MessageBox.Show("read failed!");
	}
	reader2.Close();
	connect.Close();
