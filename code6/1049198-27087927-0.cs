    public class ImageFileConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, string language)
    	{
    		string fileName = value as string;
    		
    		if (fileName != null)
    		{
    			BitmapImage bitmap = new BitmapImage();
    			bitmap.UriSource = new Uri("ms-appdata:///local/" + fileName);
    			return bitmap;
    		}
    		return null;
    	}
    	public object ConvertBack(object value, Type targetType, object parameter, string language)
    	{
    		throw new NotImplementedException();
    	}
    }
