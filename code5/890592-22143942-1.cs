	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		leftColumn.Width = new GridLength(0);
		leftSplitter.Visibility = System.Windows.Visibility.Collapsed;
	}
	private void Button_Click_2(object sender, RoutedEventArgs e)
	{
		leftColumn.Width = new GridLength(40);
		rightColumn.Width = new GridLength(40);
		leftSplitter.Visibility = System.Windows.Visibility.Visible;
		rightSplitter.Visibility = System.Windows.Visibility.Visible;
	}
	private void Button_Click_3(object sender, RoutedEventArgs e)
	{
		rightColumn.Width = new GridLength(0);
		rightSplitter.Visibility = System.Windows.Visibility.Collapsed;
	}
