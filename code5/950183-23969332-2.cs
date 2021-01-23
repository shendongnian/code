    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                double? dValue = value as double?;
                if (!dValue.HasValue) return Binding.DoNothing;
    
                var items = parameter.ToString().Split(' ');
                if(items.Length == 2)
                {
                    double cValue;
                    if(!double.TryParse(items[1], out cValue))
                        return Binding.DoNothing;
    
                    switch (items[0])
                    {
                        case "<":
                            if (dValue.Value < cValue)
                                return new SolidColorBrush(Colors.Red);
                            break;
                        case ">":
                            if (dValue.Value > cValue)
                                return new SolidColorBrush(Colors.Red);
                            break;
                        default:
                            break;
                    }
                }
            }
            return Binding.DoNothing;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
