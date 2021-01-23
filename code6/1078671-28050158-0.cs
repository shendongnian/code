      void MainWindow_Loaded(object sender, RoutedEventArgs e)
	  {
           // comboBox is an element in 'MainWindow'
		   var popup = VisualTreeHelperExtensions.FindVisualChild<Popup>(comboBox);
	  }
      public static T FindVisualChild<T>(DependencyObject depObj) where T : Visual
		{
			if (depObj != null && IsVisual(depObj))
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T)
					{
						return (T)child;
					}
					foreach (T childOfChild in FindVisualChildren<T>(child))
					{
						return childOfChild;
					}
				}
			}
			return null;
		}    
