    public class MyAttachedProperty
    {
        public static readonly DependencyProperty IsCheckedToStrProperty =
            DependencyProperty.RegisterAttached("IsCheckedToStr", typeof (string), typeof (MyAttachedProperty), new PropertyMetadata(default(string,IsCheckedToStr)))
            private static void IsCheckedToStr(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                RadioButton radio = d as RadioButton;
                radio.Checked+=radio_Checked;
            }
            private static void radio_Checked(object sender, RoutedEventArgs e)
            {
 	            RadioButton radio = sender as RadioButton;
    
                if (radio.IsChecked == true)
                {
                    SetIsCheckedToStr(radio, radio.Content.ToString());
                }
            }
        public static void SetIsCheckedToStr(UIElement element, string value)
        {
            element.SetValue(IsCheckedToStrProperty, value);
        }
        public static string GetIsCheckedToStr(UIElement element)
        {
            return (string) element.GetValue(IsCheckedToStrProperty);
        }
    }
