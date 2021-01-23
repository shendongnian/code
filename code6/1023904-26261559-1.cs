    public static class ControlExtensions
	{
        public static bool IsLoaded(this FrameworkElement element)
		{
			return element.GetVisualChildren().Any();
			//I'm not sure if this alternative is better:
			//return control.GetVisualParent() != null;
		}
    }
