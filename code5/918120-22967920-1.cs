    public class PathToBitmapConverter : IValueConverter
    {
    
    	public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
    	{
    		string filePath = (string)value;
    
    		if ( String.IsNullOrEmpty( filePath ) )
    		{
    			return null;
    		}
    		if ( !File.Exists( filePath ) )
    		{
    			return null;
    		}
    
    		BitmapImage bitmapImage;
    		try
    		{
    			using ( var fileStream = new FileStream( filePath, FileMode.Open, FileAccess.Read ) )
    			{
    				bitmapImage = new BitmapImage();
    				bitmapImage.BeginInit();
    				bitmapImage.StreamSource = fileStream;
    				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
    				bitmapImage.EndInit();
    				bitmapImage.Freeze();
    
    				fileStream.Close();
    			}
    		}
    		catch
    		{
    			bitmapImage = null;
    		}
    
    		return bitmapImage;
    	}
    
    	public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
    	{
    		throw new NotImplementedException();
    	}
    }
