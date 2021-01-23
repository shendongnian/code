    public class NullableCheckbox : DependencyObject
    {
        public static bool GetEnabled(DependencyObject obj)
        { return (bool)obj.GetValue(EnabledProperty); }
        public static void SetEnabled(DependencyObject obj, bool value)
        { obj.SetValue(EnabledProperty, value); }
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(NullableCheckbox), new PropertyMetadata(false, EnabledChanged));
        private static void EnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var checkbox = d as CheckBox;
            if ((bool)e.NewValue)
            {
                var binding = new Binding
                {
                    Path = new PropertyPath("IsChecked"),
                    Mode = BindingMode.TwoWay,
                    Source = checkbox,
                };
                checkbox.SetBinding(NullableCheckbox.InternalStateProperty, binding);
            }
        }
        private static object GetInternalState(DependencyObject obj)
        { return (object)obj.GetValue(InternalStateProperty); }
        private static void SetInternalState(DependencyObject obj, object value)
        { obj.SetValue(InternalStateProperty, value); }
        private static readonly DependencyProperty InternalStateProperty =
            DependencyProperty.RegisterAttached("InternalState", typeof(object),
            typeof(NullableCheckbox), new PropertyMetadata(null, InternalStateChanged));
        private static void InternalStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        { SetIsChecked(d, (object)e.NewValue); }
        public static object GetIsChecked(DependencyObject obj)
        { return (object)obj.GetValue(IsCheckedProperty); }
        public static void SetIsChecked(DependencyObject obj, object value)
        { obj.SetValue(IsCheckedProperty, value); }
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.RegisterAttached("IsChecked", typeof(object),
            typeof(NullableCheckbox), new PropertyMetadata(default(object), IsCheckedChanged));
        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var checkbox = d as CheckBox;
            bool? newvalue = null;
            if (e.NewValue is bool?)
                newvalue = (bool?)e.NewValue;
            else if (e.NewValue != null)
            {
                bool newbool;
                if (!bool.TryParse(e.NewValue.ToString(), out newbool))
                    return;
                newvalue = newbool;
            }
            if (!checkbox.IsChecked.Equals(newvalue))
                checkbox.IsChecked = newvalue;
        }
    }
