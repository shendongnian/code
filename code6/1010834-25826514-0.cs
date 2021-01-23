    public static class VisualTreeHelperExtensions
	{
		public static T FindVisualParent<T>(DependencyObject depObj) where T : DependencyObject
		{
			var parent = VisualTreeHelper.GetParent(depObj);
			if (parent == null || parent is T)
				return (T)parent;
			return FindVisualParent<T>(parent);
		}
		public static T FindVisualChild<T>(DependencyObject depObj) where T : Visual
		{
			if (depObj != null)
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
		public static T FindVisualChild<T>(DependencyObject depObj, string name) where T : FrameworkElement
		{
			if (depObj != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T && (child as T).Name.Equals(name))
					{
						return (T)child;
					}
					foreach (T childOfChild in FindVisualChildren<T>(child))
					{
						if (childOfChild.Name.Equals(name))
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
				DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
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
