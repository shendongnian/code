        public class AltBackgroundConverter : IValueConverter
        {
            private Brush whiteBrush = new SolidColorBrush(Colors.White);
            private Brush grayBrush = new SolidColorBrush(Colors.Gray);
    
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (!(value is int)) return null;
                int index = (int)value;
    
                if (index % 2 == 0)
                    return whiteBrush;
                else
                    return grayBrush;
            }
    
            // No need to implement converting back on a one-way binding
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
