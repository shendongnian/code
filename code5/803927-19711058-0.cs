        private void EqualButton_Click(object sender, EventArgs e)
		{
			ClearDisplayBeforeNextTextEntry = true;
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			// New code
			ClearText();
			// Old code
			DisplayTextBox.Text = DisplayTextBox.Text + "1";
		}
		// Same for all other number buttons as above
		private void ClearText()
		{
			if (ClearDisplayBeforeNextTextEntry)
			{
				DisplayTextBox.Text = "";
				ClearDisplayBeforeNextTextEntry = false;
			}
		}
