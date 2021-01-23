     public sealed class StatusToImageConvertor : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
	    // The value here is your status being passed from XAML binding
            if (value is string)
            {
               if(value == "x") return "image1.png";
	       if(value = "y") return "image2.png";
	       else return "image3.png";
	    }
	    else return string.empty;	
           
        }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
