    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace WpfPlayground
    {
        public class CanAbortConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value.ToString() == "")
                {
                    return true;
                }
                return false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Binding.DoNothing;
            }
    
        }
    }
