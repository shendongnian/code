    private void BtnAdd_Click(object sender, RoutedEventArgs e)
	{
		if (!tb1.Text.Equals(""))
		{
			var query1 = users.Where(User => User.Id == int.Parse(tb1.Text));
			if (!query1.Any())
			{
				users.Add(new User() { Id = int.Parse(tb1.Text), Name = tb2.Text, Salary = int.Parse(tb3.Text) });
			}
		}
			
	}
