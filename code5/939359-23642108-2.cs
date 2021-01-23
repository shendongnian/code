    public class BoolDecisionToStringConverter : IValueConverter
    {
       public object Convert (...)
       {
          string[] args = String.Split((String)parameter, ';');
          if ((bool)value)
             return args[0];
          else
             return args[1];
       }
    
       public object ConvertBack (...)
       {
          //We don't care about this one for this converter
          throw new NotImplementedException();
       }
    }
