      using System;
        using System.Globalization;
        using System.Windows.Data;
        
        namespace TestWpf
        {
            public class NameAndCheckBoxMultiValueConverter: IMultiValueConverter
            {
                public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
                {
                var lastName = values[0] as String;
                if(lastName != null)
                {
                    var isChecked = (bool)values[1];
                    if (isChecked)
                    {
                        return lastName.Substring(0,1);
                    }
                    return lastName;
                }
                return null;
                }
        
                public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
        }
