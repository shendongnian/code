    public interface IBoundDataColumn
    {
        public string Name { get; } // Not really necessary for the template selector, but perhaps for completeness
        public object Value { get; }
    }
    public class DateTimeColumn : IBoundDataColumn
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class TemplateSelector : DataTemplateSelector
	{
		public DataTemplate TextFieldTemplate
		{
			get;
			set;
		}
		public DataTemplate DateTimeFieldTemplate
		{
			get;
			set;
		}
		public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
		{
			IBoundDataColumn boundCol = item as IBoundDataColumn;
            if (boundCol.Value.GetType() == typeof(DateTime))
            {
                return DateTimeFieldTemplate;
            }
            else
            {
                return TextFieldTemplate;
            }
			return base.SelectTemplate(item, container);
		}
	}
