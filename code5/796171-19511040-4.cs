    private void tb1_TextChanged(object sender, TextChangedEventArgs e)
	{
		int output;
		if (!int.TryParse(tb1.Text, out output))
		{
			MessageBox.Show("Enter valid int.");
			tb1.Text = "0";
		}
	}
