    public class MultiButtonCheckedToVisibilityConverter : IMultiValueConverter
    {
    	public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		bool visible = false;
    		int trueCount = (int)parameter;
    			
    		for (int i = 0; i < trueCount; i++)
    		{
    			if ((bool)values[i]) 
    			{
    				visible = true;
    				break;
    			}
    		}
    
    		if (visible)
    		{
    			for (int i = trueCount; i < values.Length; i++)
    			{
    				if (!(bool)values[i])
    				{
    					visible = false;
    					break;
    				}
    			}
    		}
    
    		if (visible)
    		{
    			return System.Windows.Visibility.Visible;
    		}
    		else
    		{
    			return System.Windows.Visibility.Hidden;
    		}
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
