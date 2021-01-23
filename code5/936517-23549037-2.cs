	private void button1_Click(object sender, EventArgs e)
	{
		User user = new User("India");
		var myarr = comboBox1.Items.OfType<DataTable>().ToArray();
		foreach (var item in myarr)
		{
			if (item.name.Equals(user.city))
			{
				comboBox1.SelectedItem = item;
				break;
			}
		}
	}
