     private void Window_Loaded(object sender, RoutedEventArgs e)
     {
     	var hyperlinks = GetVisuals(this).OfType<Hyperlink>();
     	foreach (var link in hyperlinks)
     	link.RequestNavigate += link_RequestNavigate;
     }
     public static IEnumerable<DependencyObject> GetVisuals(DependencyObject root)
     {
	     foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
	     {
		     yield return child;
		     foreach (var descendants in GetVisuals(child))
			     yield return descendants;
	     }
     }
