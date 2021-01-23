        
    static [CustomControl]()
	{
		UIElement.IsEnabledProperty.OverrideMetadata(typeof([CustomControl]), new UIPropertyMetadata(true, [CustomControl]_IsEnabledChanged, CoerceIsEnabled));
	}
	private static void [CustomControl]_IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var childrenCount = VisualTreeHelper.GetChildrenCount(d);
		for (int i = 0; i < childrenCount; ++i)
		{
			var child = VisualTreeHelper.GetChild(d, i);
			child.CoerceValue(UIElement.IsEnabledProperty);
		}
	}
	private static object CoerceIsEnabled(DependencyObject d, object basevalue)
	{
		var parent = VisualTreeHelper.GetParent(d) as FrameworkElement;
		if (parent != null && parent.IsEnabled == false)
		{
			if (d.ReadLocalValue(UIElement.IsEnabledProperty) == DependencyProperty.UnsetValue)
			{
				return false;
			}
		}
		return basevalue;
	}
