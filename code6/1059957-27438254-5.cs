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
            // your logic do determine what template you need goes here
			if (...) {
					return TextBoxTemplate;
				}
				else if (...){
					return ExpanderTemplate;
				}
        }
    }
