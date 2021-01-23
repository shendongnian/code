	private void FilterComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
	{
		var cb = sender as CheckBox;
		if (cb != null)
		{
			cb.IsChecked = !cb.IsChecked;
			e.Handled = true;
		}
	}
