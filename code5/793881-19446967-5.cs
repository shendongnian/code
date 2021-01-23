    private void BtnAdd_Click(object sender, RoutedEventArgs e)
	{
		if (!tb1.Text.Equals("")) //checks if tb1 is not empy
		{
			var query1 = users.Where(User => User.Id == int.Parse(tb1.Text)); //creates a variable query1 with all users who have same ID as the one in tb1, I do this to block the same ID insertion
			if (!query1.Any()) //if the query1 is empty, meaning there are no users with given id
			{
				users.Add(new User() { Id = int.Parse(tb1.Text), Name = tb2.Text, Salary = int.Parse(tb3.Text) }); // adds new user to the list
			}
		}
			
	}
