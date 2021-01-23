	protected void Button1_Click(object sender, EventArgs e)
	{
		ListBox1.Items.Clear();
		string[] files = Directory.GetFiles(Server.MapPath("~/images"), "*.*", SearchOption.AllDirectories);
		foreach (string item in files)
		{
			string fileName = Path.GetFileName(item);
			if (fileName.ToLower().Contains(TextBox1.Text.ToLower()))
			{
				string subPath = item.Substring(Server.MapPath("~/images").Length).Replace("\\","/");
				ListBox1.Items.Add(new ListItem(fileName, subPath));
			}
		}
	}
