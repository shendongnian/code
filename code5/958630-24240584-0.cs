    class FindingLogicalChildren
	{
		public static IEnumerable<T> FindVisualChildren<T>(DependencyObject dependencyObject) where T : DependencyObject
		{
			if (dependencyObject != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
					if (child != null && child is T)
					{
						yield return (T)child;
					}
					foreach (T childOfChild in FindVisualChildren<T>(child))
					{
						yield return childOfChild;
					}
				}
			}
		}
