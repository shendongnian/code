	private void textBox1_TextChanged(object sender, EventArgs e)
	{
		if (a.Equals(b))
		{
			result = a.ToString();
			textBox1.Text = result;
			textBox1.TextAlign = HorizontalAlignment.Left;
		}
		else
		{
			result = b.ToString();
			textBox1.Text = result;
			textBox1.TextAlign = HorizontalAlignment.Center;
		}
	}
