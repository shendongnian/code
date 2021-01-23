    class IsEnabledConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, 
                             System.Globalization.CultureInfo culture) {
        if(values.Length == 2){
          return  (bool) values[0] && (bool) values[1];
        }
        return false;
      }
      //... omit ConvertBack NotImplementedException stuff
    }
