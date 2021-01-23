    public class BoolToAuthenticationStringConverter : IValueConverter
    {
       public object Convert (...)
       {
          if ((bool)value)
             return "Authenticated!";
          else
             return "Not Authenticated!";
       }
    
       public object ConvertBack (...)
       {
          //We don't care about this one for this converter
          throw new NotImplementedException();
       }
    }
