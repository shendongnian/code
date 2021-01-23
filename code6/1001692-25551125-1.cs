	private void MainForm_Load(object sender, EventArgs e)
	{
		foreach (Control c in this.Controls)
			{
			if (c is TextBox)
				{
					c.GotFocus += deleteContent_GotFocus; // No need for more than that ;)
					c.LostFocus += restoreContent_LostFocus;
				}  
			}
		}
	private void deleteContent_GotFocus(object sender, EventArgs e)
	{
		if ((sender is TextBox))
		{
			// Using "as" instead of parenthesis cast is good practice
			(sender as TextBox).Text = String.Empty; // hey, use Microsoft's heavily verbosy stuff already! :o
		}
	}
	
	private void restoreContent_LostFocus(object sender, EventArgs e)
	{
		if ((sender is TextBox))
		{
			TextBox tb = sender as TextBox;
			if (!String.IsNullOrEmpty(tb.text)) // or String.IsNullOrWhiteSpace
				tb.Text = "0";
		}
	}
