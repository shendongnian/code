	public static IEnumerable<FrameworkElement> visualParents( this FrameworkElement e )
	{
		DependencyObject obj = e;
		while( true )
		{
			obj = VisualTreeHelper.GetParent( obj );
			if( null == obj ) yield break;
			FrameworkElement fwe = obj as FrameworkElement;
			if( null != fwe ) yield return fwe;
		}
	}
	public static bool isOnVisibleTab( FrameworkElement elt )
	{
		TabItem item = elt.visualParents().OfType<TabItem>().FirstOrDefault();
		if( null == item )
			return true;         // Did not find the tab, return true
		return item.IsSelected;  // Found the tab, return true if the tab is selected
	}
