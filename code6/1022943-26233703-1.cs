    public static class ControlExtensions
	{
        public static bool IsRoutedEventFromToggleButton(
            this RoutedEventArgs args,
            UIElement togglebuttonAncestorToStopTheSearch )
		{
			ToggleButton toggleButton = ((UIElement) args.OriginalSource)
                .GetAncestor<ToggleButton>( togglebuttonAncestorToStopTheSearch );
			return toggleButton != null;
		}
        public static TAncestor GetAncestor<TAncestor>(
            this DependencyObject subElement,
            UIElement potentialAncestorToStopTheSearch )
			where TAncestor : DependencyObject
		{
			DependencyObject parent;
			for (DependencyObject subControl = subElement; subControl != null;
                 subControl = parent)
			{
				if (subControl is TAncestor) return (TAncestor) subControl;
				if (object.ReferenceEquals( subControl,
                    potentialAncestorToStopTheSearch )) return null;
				parent = VisualTreeHelper.GetParent( subControl );
				if (parent == null)
				{
					FrameworkElement element = subControl as FrameworkElement;
					if (element != null)
					{
						parent = element.Parent;
					}
				}
			}
			return null;
		}
    }
