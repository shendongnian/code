    public sealed class CachedImageConverter: IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, string language)
    	{            
    		var path = value as string;
    		if (path == null)
    			return null;
    		var app = App.Current as App;
    		return app.ImageHelper.ImageFromRelativePath(new Uri("ms-appx:/"), path);
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, string language)
    	{
    		throw new NotImplementedException();
    	}
    }
