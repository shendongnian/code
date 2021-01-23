       public object MySelectedItem
            {
                get { return (object)GetValue(MySelectedItemProperty); }
                set { SetValue(MySelectedItemProperty, value); }
            }
        // Using a DependencyProperty as the backing store for MySelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MySelectedItemProperty =
            DependencyProperty.Register("MySelectedItem", typeof(object), typeof(YOURUSERCONTROLTYPE), new UIPropertyMetadata(null));
