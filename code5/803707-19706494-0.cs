        public EventHandler MyProperty
        {
            get { return (EventHandler)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty = DependencyProperty.Register("MyProperty", typeof(EventHandler), typeof(ownerclass));
