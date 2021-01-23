    public class DataTemplateSelector : DataTemplateSelector
	{
		#region Properties
		
		public DataTemplate TextBoxTemplate
		{
			get;
			set;
		}
		
		public DataTemplate ExpanderTemplate
		{
			get;
			set;
		}
    
        public override Template SelectTemplate(object item, DependencyObject container)
		{
			...
        }
    }
