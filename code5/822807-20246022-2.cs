    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Windows.Media;
    
    namespace WpfTestBench
    {
        public class IntToColorConverter : MarkupExtension, IValueConverter
        {
            private static IntToColorConverter _instance;
    
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var convertedValue = (int)value;
    
                if (convertedValue < 5)
                    return new SolidColorBrush(Colors.White);
    
                if (convertedValue < 10)
                    return new SolidColorBrush(Colors.Green);
    
                if (convertedValue < 15)
                    return new SolidColorBrush(Colors.Yellow);
    
                return new SolidColorBrush(Colors.Red);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
    
            #endregion
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return _instance ?? (_instance = new IntToColorConverter());
            }
        }
    }
