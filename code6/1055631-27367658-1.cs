    public class MultiDataValueConverter: IMultiValueConverter
        {
    
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {                    
                int version = (int)(values[1]);
                    
                string format = "0.0000";
                if(version==2)
                {
                    format = "0.000000";
                }
    
                double val = (double)(values[0]);
                return val.ToString(format);            
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
