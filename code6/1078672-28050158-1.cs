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
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
		{
			if (depObj == null)
				yield break;
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
			{
				if (IsVisual(depObj))
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T)
					{
						yield return (T) child;
					}
					foreach (T childOfChild in FindVisualChildren<T>(child))
					{
						yield return childOfChild;
					}
				}
			}
		}
		private static bool IsVisual(DependencyObject depObj)
		{
			return depObj is Visual || depObj is Visual3D;
		}
