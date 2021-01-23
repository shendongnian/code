        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is double))
                return DependencyProperty.UnsetValue;
            
            double doubleValue = (double)value;
            return doubleValue + 65.0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // No need to implement, since the binding is in one way mode.
            throw new NotImplementedException();
        }
    }
    Binding binding1 = new Binding();
                binding1.Converter = new Label1offset();
                binding1.Source = cage;
                binding1.Path = new PropertyPath(Canvas.TopProperty);
                binding1.Mode = BindingMode.OneWay;
                to1.SetBinding(Canvas.TopProperty, binding1);
