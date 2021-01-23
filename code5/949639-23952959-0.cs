You could use the TextChangedEvent like so:
    protected void nameContactUsTextBox_TextChanged(object sender, EventArgs e)
    {
    	nameErrorLabel.Visible = nameContactUsTextBox.Text == "";
    }
