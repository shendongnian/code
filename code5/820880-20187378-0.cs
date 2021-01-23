		private void ValidateTextBox(object sender)
		{
			TextBox textBox = (sender as TextBox);
			if (textBox == null)
				return;
			if (string.IsNullOrEmpty(textBox.Text))
			{
				textBox.Focus();
				textBox.BackColor = Color.Red;
			}
		}
