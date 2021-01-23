	private string AddButton()
	{
		string sql = "SELECT projectType, clientName, projectNo, Client.clientNo FROM Project, Client WHERE Project.ClientNo = Client.ClientNo;";
		newConnection = new ConnectToDatabase(sql);
		dataReader = newConnection.NewDataReader();
		while (dataReader.Read())
		{
			newButton = new Button();
			newButton.Font = new Font("Georgia", 12);
			newButton.Size = new Size(194, 80);
			newButton.Name = dataReader.GetValue(3).ToString();
			newButton.Text = dataReader.GetValue(1).ToString() + "\n" + dataReader.GetValue(0);
			flpDisplayProjects.Controls.Add(newButton);
			newButton.Click += (s, e) =>
			{
				string sql = "SELECT projectType, clientName, projectNo FROM Project, Client WHERE Project.ClientNo = Client.ClientNo AND " +
				"clientName = '" + newButton.Name + "';";
				newConnection = new ConnectToDatabase(sql);
				dataReader = newConnection.NewDataReader();
				timeTrackingForm newForm = new timeTrackingForm(dataReader);
				newForm.Show();
			};
		}
		return newButton.Name;
	}
