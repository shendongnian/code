    public sealed class SingletonValueConverter : IValueConverter
    {
    	private static SingletonValueConverter instance;
    
    	// Explicit static constructor to tell C# compiler
    	// not to mark type as beforefieldinit
    	static SingletonValueConverter() {
    	}
    
    	private SingletonValueConverter() {
    	}
    
    	public static SingletonValueConverter Instance {
    	get { return instance ?? (instance = new SingletonValueConverter()); }
    
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    		return ...
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    		return ...
    	}
    }
