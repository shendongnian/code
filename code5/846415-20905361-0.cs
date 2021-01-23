	class Placeholder
	{
		private MyTextBox textBox;
		private bool active = false;
		private char? originalPasswordChar = null;
		public bool Active
		{
			get { return active; }
			set
			{
				if (value)
				{
					textBox.ForeColor = ForeColor;
					textBox.Text = Text;
					if (originalPasswordChar == null) originalPasswordChar = textBox.PasswordChar;
				}
				else if (active && !value)
				{
					textBox.ForeColor = previousForeColor;
					textBox.Text = string.Empty;
					textBox.PasswordChar = originalPasswordChar.Value;
					originalPasswordChar = null; 
				}
				active = value;
			}
		}
		// (...)
	}
