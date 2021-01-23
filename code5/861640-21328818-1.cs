	//Reading all lines of Text file
	var allLines = File.ReadAllLines(@"D:\test1.txt");
	var connectionString = @"DataSource=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Database.mdf;Integrated   Security=True;User Instance=True";
	using (SqlConnection connection = new SqlConnection(connectionString))
	{
		SqlCommand cmd = connection.CreateCommand();
		foreach (var line in allLines)
		{
			var items = line.Split(new[] { '\t', '\n' }).ToArray();
			if (items.Length != 3)
				continue;
			var Name = items[0].ToString();
			var Email = items[1].ToString();
			var Pwd = items[2].ToString();
			cmd.CommandText = "insert into Employees values('" + Name + "','" + Email + "','" + Pwd + "')";
			cmd.CommandType = CommandType.Text;
			cmd.ExecuteNonQuery();
		}
		Label1.Visible = true;
		Label1.Text = "Data Successfully Inserted into Database.";
	}
