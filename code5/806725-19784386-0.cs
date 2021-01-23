    public class ImagesEnumToSourceConverter: IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if(value is ImagesEnum)
    		{
    			switch((ImagesEnum)value)
    			{
    				case ImagesEnum.Image1:
    					return "../Resources/MyImages/Image1.png";
    				case ImagesEnum.Image2:
    					return "../Resources/MyImages/Image2.png";
    				case ImagesEnum.Image3:
    					return "../Resources/MyImages/Image3.png";
    			}
    		}
    		return DependencyProperty.UnsetValue;
    	}
    }
