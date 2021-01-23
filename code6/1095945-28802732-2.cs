    class ValueToBackgroundConverter : DependencyObject, IValueConverter
        {
            public string BackgroundColor
            {
                get { return (string)GetValue(BackgroundColorProperty); }
                set { SetValue(BackgroundColorProperty, value); }
            }
    
            public static readonly DependencyProperty BackgroundColorProperty =
             DependencyProperty.Register("BackgroundColor",
                                         typeof(string),
                                         typeof(ValueToBackgroundConverter), null
                                         );
    
            public object Convert(object value, System.Type targetType, object parameter, string language)
            {
    //I've used static colors but you can do manipulations to convert string to color brush
                if (BackgroundColor != null)
                    return new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0xCE, 0xDC));
                else
                    return new SolidColorBrush(Color.FromArgb(0xFF, 0xE3, 0xF0, 0xF4));
            }
    
            public object ConvertBack(object value, System.Type targetType, object parameter, string language)
            {
                throw new System.NotImplementedException();
            }
        }
