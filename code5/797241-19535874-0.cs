    private void txtBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
	{
		int number;
		decimal dnumber;
		if (int.TryParse(txtBox.Text, out number) || decimal.TryParse(txtBox.Text, out dnumber))
		{
			//process further if true
		}
	}
