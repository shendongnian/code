	public void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
		{
		  MessageBox.Show("Pressed " + Keys.Shift);
		}
	}
