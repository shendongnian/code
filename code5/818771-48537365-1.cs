	private void AutoCompleteBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
	{
		var _acb = sender as AutoCompleteBox;
		if(_acb != null && string.IsNullOrEmpty(_acb.Text))
		{
			_acb.Dispatcher.BeginInvoke((Action)(() => { _acb.IsDropDownOpen = true; }));
		}
	}
