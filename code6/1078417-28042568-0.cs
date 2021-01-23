	public static class ItemsControlExtensions
	{
		public static IEnumerable<TElement> GetElementsOfType<TElement>(
            this ItemsControl itemsControl, string named)
			where TElement : FrameworkElement
		{
			ItemContainerGenerator generator = itemsControl.ItemContainerGenerator;
			return
                from object item in itemsControl.Items
				let container = generator.ContainerFromItem(item)
				let element = GetDescendantByName(container as FrameworkElement, named)
				where element != null
				select (TElement) element;
		}
		static FrameworkElement GetDescendantByName(FrameworkElement element,
            string elementName)
		{
			if (element == null)
			{
				return null;
			}
			if (element.Name == elementName)
			{
				return element;
			}
			element.ApplyTemplate();
			FrameworkElement match = null;
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
			{
				var child = VisualTreeHelper.GetChild(element, i) as FrameworkElement;
				match = GetDescendantByName(child, elementName);
				if (match != null)
				{
					break;
				}
			}
			return match;
		}
	}
