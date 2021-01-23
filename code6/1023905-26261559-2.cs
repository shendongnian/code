    public static class FrameworkElementExtensions
	{
        public static bool IsLoaded(this FrameworkElement element)
		{
			return element.GetVisualChildren().Any();
			//I'm not sure if this alternative is better:
            //return System.Windows.Media.VisualTreeHelper.GetParent(element)!= null;
            //or
			//return element.GetVisualParent() != null;
		}
    }
