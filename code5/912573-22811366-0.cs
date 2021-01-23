    public T ParentOfType<T>(DependencyObject element) where T : DependencyObject
	{
		if (element == null)
		return default (T);
		else
		return Enumerable.FirstOrDefault<T>(Enumerable.OfType<T>((IEnumerable) GetParents(element)));
	}
	
	public IEnumerable<DependencyObject> GetParents( DependencyObject element)
	{
		if (element == null)
			throw new ArgumentNullException("element");
		while ((element = GetParent(element)) != null)
			yield return element;
	}
	
	private DependencyObject GetParent(DependencyObject element)
	{
		DependencyObject parent = VisualTreeHelper.GetParent(element);
		if (parent == null)
		{
			FrameworkElement frameworkElement = element as FrameworkElement;
			if (frameworkElement != null)
				parent = frameworkElement.Parent;
		}
		return parent;
	}
