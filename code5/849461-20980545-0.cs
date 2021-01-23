    public object Convert(object value, Type targetType, object parameter,
                      System.Globalization.CultureInfo culture)        
    {
        if (value is MyContentType)
        {
          return (value as MyContentType).Property
        }
        else
        { 
           return defaultValue // this value is valid for wpf control property
        }
   
    }         
    
