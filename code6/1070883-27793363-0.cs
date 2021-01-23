    class FontSizeConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, 
             System.Globalization.CultureInfo culture) {
        // add input parameter testing as needed.
        var originalFontSize = (double)value;
        double alteredFontSize = originalFontSize * Ratio; ;   
    
        return alteredFontSize;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
      }
    
      // Create a ratio property 
      // allows the converter to be used for different font ratios
      public double Ratio { get; set; }
    }
