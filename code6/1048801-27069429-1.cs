     public class Color : DependencyObject
        {
            private static readonly DependencyProperty CustomBackgroundProperty =
                DependencyProperty.RegisterAttached("CustomBackground", typeof(SolidColorBrush), typeof(Color),
                    new PropertyMetadata(null));
    
            public static void SetCustomBackground(DependencyObject obj, SolidColorBrush color)
            {
                obj.SetValue(CustomBackgroundProperty, color);
            }
    
            public static SolidColorBrush GetCustomBackground(DependencyObject obj)
            {
                return (SolidColorBrush)obj.GetValue(CustomBackgroundProperty);
            }
        }
    
