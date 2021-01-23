    public class ControlTemplateConverter
    {
        public static readonly DependencyProperty IsEnabledProperty =
                DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ControlTemplateConverter), new UIPropertyMetadata(false, IsEnabledChanged));
    
        private static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ControlTemplate t;
            if (d == null) return;
            if (d is TextBlock)
                t = App.Current.FindResource("TextBoxTemplate") as ControlTemplate;
            else if (d is CheckBox)
                t = App.Current.FindResource("CheckBoxTemplate") as ControlTemplate;
            // and So On
                
            (d as Control).Template = t;
        }
    
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
    } 
