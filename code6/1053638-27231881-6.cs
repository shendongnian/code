	private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(comboBoxName.Text))  // Text instead of SelectedText
		{
			fillMake();
		}
	}
