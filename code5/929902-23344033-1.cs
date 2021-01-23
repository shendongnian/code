    public class BoolToColorConverter
      : IValueConverter{
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
    
            return (value is bool && (bool)value) ? Application.Current.Resources["PhoneAccentBrush"] : Application.Current.Resources["PhoneSubtleBrush"];
            }
    }
