        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v => v == null || v == DependencyProperty.UnsetValue || string.IsNullOrEmpty(v.ToString()))) return Visibility.Collapsed;
            return Visibility.Visible;
        }
