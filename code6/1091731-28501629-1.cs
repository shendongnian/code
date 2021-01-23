	private void Form1_Load(object sender, EventArgs e)
	{
		foreach (Control ctrl in this.Controls)
		{
			if ((ctrl as TextBox) != null)
			{
				(ctrl as TextBox).TextChanged += Form1_TextChanged;
			}
		}
	}
	private void Form1_TextChanged(object sender, EventArgs e)
	{
		MessageBox.Show((sender as TextBox).Name);
	}
