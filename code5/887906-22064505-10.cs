    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace WpfApplication2
    {
        public class NodeWidthConverter : IValueConverter 
        {
            public static Random Random = new Random();
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Random.Next(200, 600);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
