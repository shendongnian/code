    public class NullableCheckbox : DependencyObject
    {
        public object InternalState
        {
            get { return (object)GetValue(InternalStateProperty); }
            set { SetValue(InternalStateProperty, value); }
        }
        public static readonly DependencyProperty InternalStateProperty =
            DependencyProperty.Register("InternalState", typeof(object),
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
        private static bool RunFirstTime = true;
        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var checkbox = d as CheckBox;
            var newvalue = (bool?)e.NewValue;
            if (!checkbox.IsChecked.Equals(newvalue))
                checkbox.IsChecked = newvalue;
            if (RunFirstTime)
            {
                RunFirstTime = false;
                // set custom prop when ischecked changes
                var binding = new Binding
                {
                    Path = new PropertyPath("IsChecked"),
                    Mode = BindingMode.TwoWay,
                    Source = checkbox,
                };
                checkbox.SetBinding(NullableCheckbox.InternalStateProperty, binding);
            }
        }
    }
