     public static T GetVisualChild<T>(DependencyObject depObj) where T : Visual
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
					foreach (T childOfChild in GetVisualChild<T>(child))
					{
						return childOfChild;
					}
				}
		   }
		   return null;
	  }
