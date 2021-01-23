    class TemplateSelectorMyPage : DataTemplateSelector
    	{
    		public DataTemplate NormalIconTemplate { get; set; }
    		public DataTemplate BigIconTemplate { get; set; }
    
    		protected override DataTemplate SelectTemplateCore( object item, DependencyObject container )
    		{
    			var uiElement = container as UIElement;
    			if( uiElement == null )
    			{
    				return base.SelectTemplateCore( item, container );
    			}
    
    			if ( item is BigIconItem )
    			{
    				return BigIconTemplate;
    			}
    			else if ( item is NormalIconItem )
    			{
    				return NormalIconTemplate;
    			}
    			return base.SelectTemplateCore( item, container );
    		}
