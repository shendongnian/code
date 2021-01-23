     Quark _lastSeenValue;
     public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Quark paramQuark = (Quark)parameter;
            Quark currentQuark = (Quark)value;
            _lastSeenValue = currentQuark;
            return currentQuark.HasFlag(paramQuark);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Quark newQuark = _lastSeenValue;
            Quark paramQuark = (Quark)parameter;
            if ((bool)value)
            {
                newQuark |= paramQuark; 
            }
            else
            {
                newQuark &= ~paramQuark;
            }
            _lastSeenValue = newQuark;
            return newQuark;
        }
