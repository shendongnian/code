    public static DataTemplate FindTemplateForType(Type dataType, DependencyObject container)
	{
		var frameworkElement = container as FrameworkElement;
		if (frameworkElement != null)
		{
			frameworkElement = FindClosestResources(frameworkElement);
			var template = FindTemplateForType(dataType, frameworkElement.Resources);
			if (template != null)
				return template;
		}
		if (!(container is Visual || container is Visual3D))
		{
			container = FindClosestVisualParent(container);
			return FindTemplateForType(dataType, container);
		}
		else
		{
			var parent = VisualTreeHelper.GetParent(container);
			if (parent != null)
				return FindTemplateForType(dataType, parent);
			else
				return FindTemplateForType(dataType, Application.Current.Resources);
		}
	}
	private static DataTemplate FindTemplateForType(Type dataType, ResourceDictionary resources)
	{
		var entries =
			from DictionaryEntry e in resources
			where e.Key is DataTemplateKey && e.Value is DataTemplate
			let type = ((DataTemplateKey)e.Key).DataType as Type
			where type == dataType
			select e.Value as DataTemplate;
		var template = entries.FirstOrDefault();
		if (template != null)
			return template;
		foreach (var mergedDic in resources.MergedDictionaries)
		{
			template = FindTemplateForType(dataType, mergedDic);
			if (template != null)
				return template;
		}
		return null;
	}
	public static FrameworkElement FindClosestResources(FrameworkElement initial)
	{
		FrameworkElement current = initial;
		bool found = false;
		while (!found)
		{
			if (current.Resources != null && current.Resources.Count > 0)
			{
				found = true;
			}
			else
			{
				current = (FrameworkElement)VisualTreeHelper.GetParent(current);
			}
		}
		return current;
	}
	public static DependencyObject FindClosestVisualParent(DependencyObject initial)
	{
		DependencyObject current = initial;
		bool found = false;
		while (!found)
		{
			if (current is Visual || current is Visual3D)
			{
				found = true;
			}
			else
			{
				current = LogicalTreeHelper.GetParent(current);
			}
		}
		return current;
	}
