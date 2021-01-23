    public class StringToElementConverter : IValueConverter {
       public object Convert(object value, Type targetType, object parameter,
                                           CultureInfo culture){
          var pc = new ParserContext();
          pc.XmlnsDictionary[""] = 
                       "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
          pc.XmlnsDictionary["x"] = "http://schemas.microsoft.com/winfx/2006/xaml";
          return XamlReader.Parse(System.Convert.ToString(value), pc);
       }
       public object ConvertBack(object value, Type targetType, object parameter, 
                                               CultureInfo culture){
          throw new NotImplementedException();
       }
    }
