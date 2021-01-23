    public class OverRequestedForegroundMultiConverter : IMultiValueConverter
    {
    	#region IValueConverter Members
    
    	public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (value != null && value.Length == 2)
    		{
    			if (value[0] is int && value[1] is int)
    			{
    				int requested = (int)value[0];
    				int volume = (int)value[1];
    				if (requested > volume)
    					return Colors.Red;
    			}
    		}
    		return Colors.Gray; // Or whatever color you want
    	}
    
    	public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    
    	#endregion
    }
    
        public class OverRequestedTooltipMultiConverter : IMultiValueConverter
        {
        	#region IValueConverter Members
        
        	public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        	{
        		if (value != null && value.Length == 2)
        		{
        			if (value[0] is int && value[1] is int)
        			{
        				int requested = (int)value[0];
        				int volume = (int)value[1];
        				if (requested > volume)
        					return "The requested volume is greater than the available volume";
        			}
        		}
        		return null;
        	}
        
        	public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        	{
        		throw new NotImplementedException();
        	}
        
        	#endregion
        }
