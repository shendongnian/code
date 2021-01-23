    void TabSet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			foreach (TabItem item in tabControl.Items)
				item.Background = new SolidColorBrush(item.IsSelected ? Colors.Green : Colors.Red);
		}
