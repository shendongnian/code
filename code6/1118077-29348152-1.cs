    public class CustomThicknessConverter : IValueConverter
    {
        protected readonly char SplitChar = ',';
        protected readonly char ReplaceAt = '#';
        /// <summary>
        /// Create a thickness with custom format(for example #,2,#,5).
        /// </summary>
        /// Number for default width.
        /// # for given border width.
        /// ; for split the chars.
        /// For example '#,0,#,0' with 1 as value return a new thickness 
        /// with Left = 1, Top = 0, Right = 1, Bottom = 0.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == DependencyProperty.UnsetValue)
                return value;
            var borderWidth = value as double?;
            var format = parameter.ToString().Split(SplitChar); 
            if(format.Length == 1)
                return new Thickness(GetValue(borderWidth, format[0]));
            else if(format.Length == 2)
            {
                return new Thickness()
                {
                    Left    = GetValue(borderWidth, format[0]),
                    Top     = GetValue(borderWidth, format[1]),
                    Right   = GetValue(borderWidth, format[0]),
                    Bottom  = GetValue(borderWidth, format[1])
                };
            }
            else if(format.Length == 4)
            {
                return new Thickness()
                {
                    Left    = GetValue(borderWidth, format[0]),
                    Top     = GetValue(borderWidth, format[1]),
                    Right   = GetValue(borderWidth, format[2]),
                    Bottom  = GetValue(borderWidth, format[3])
                };
            }
            return new Thickness(0);
        }
        private double GetValue(double? value, string format)
        {
            if(format.FirstOrDefault() == ReplaceAt) return value ?? 0;
            double result;
            return (Double.TryParse(format, out result)) ? result : 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
