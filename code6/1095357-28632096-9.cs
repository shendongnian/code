    public static class ControlExtensions
	{
		public static bool IsFocused( this UIElement control )
		{
			DependencyObject parent;
			for (DependencyObject potentialSubControl = FocusManager.GetFocusedElement() as DependencyObject; potentialSubControl != null; potentialSubControl = parent)
			{
				if (object.ReferenceEquals( potentialSubControl, control ))
				{
					return true;
				}
				parent = VisualTreeHelper.GetParent( potentialSubControl );
				if (parent == null)
				{
					FrameworkElement element = potentialSubControl as FrameworkElement;
					if (element != null)
					{
						parent = element.Parent;
					}
				}
			}
			return false;
		}
	}
