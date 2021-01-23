	class ItemTemplateSelector : DataTemplateSelector
	{
		public DataTemplate EventTemplate { get; set; }
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if(item is Event)
			{
				return EventTemplate;
			}
			// TODO: templates for other types
			return null;
		}
	}
