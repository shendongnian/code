       public class InverseConverter : IValueConverter
	   {
		    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		    {
			   bool _val = (bool)value;
			   return !_val;
		    }
		    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		    {
		  	    bool _val = (bool)value;
			    return !_val;
		    }
	   }
        
       public MainWindow()
	   {
			InitializeComponent();
			this.DataContext = this;		
	   }
	   public List<object> Stuff
	   {
			get { return new List<object> { 1, 2, 3 }; }
	   } 
