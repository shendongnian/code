    public class MyConverter : IValueConverter
    {
       public object Convert(...)
       {
           if (value.Equals(parameter))
              return value;
           else
              return null;
       }
    
       public object ConvertBack(...)
       {
           return value;
       }
    }
