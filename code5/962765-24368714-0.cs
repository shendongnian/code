        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(TimeBox), new PropertyMetadata(false, null, CoerceReadOnly));
        private static object CoerceReadOnly(DependencyObject d, object baseValue)
        {
            if ((d as TimeBox)._Enabled == baseValue)
                return DependencyProperty.UnsetValue;
            return baseValue;
        }
