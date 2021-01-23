	public class NodePropertyGridTemplateSelector : DataTemplateSelector
	{
		private readonly Dictionary<string, DataTemplate> _dictionary = new Dictionary<string, DataTemplate>();
		public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
		{
			if (item != null)
			{
				DataTemplate dt;
				if (_dictionary.TryGetValue("PageLoaded", out dt))
					return dt;
			}
			return base.SelectTemplate(item, container);
		}
		public DataTemplate PageLoadedDataTemplate
		{
			get
			{
				DataTemplate dt;
				return _dictionary.TryGetValue("PageLoaded", out dt) ? dt : null;
			}
			set
			{
				if (value == null) _dictionary.Remove("PageLoaded");
				else _dictionary["PageLoaded"] = value;
			}
		}
	}
