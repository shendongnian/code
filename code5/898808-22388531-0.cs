    public class ParamToIntConverter : IValueConverter
    {
       public object Convert (...)
       {
           return value.Equals(int.Parse((string)parameter));
       }
    
       public object ConvertBack(...)
       {
           if ((bool)value)
              return int.Parse((string)parameter);
           else
              return Binding.DoNothing;
       }
    }
