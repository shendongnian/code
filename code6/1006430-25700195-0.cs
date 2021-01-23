	private string current;
	private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
	{
		if (string.IsNullOrEmpty(this.current))
		{
			this.current = this.TextBox.Text;
			return;
		}
		if (!this.TextBox.Text.Contains(this.current))
			this.TextBox.Text = this.current;
		else
			this.current = this.TextBox.Text;
	}
