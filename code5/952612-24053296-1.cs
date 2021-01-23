        public bool TextChanged
        {
            get { return (bool)GetValue(TextChangedProperty); }
            set { SetValue(TextChangedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextChangedProperty =
            DependencyProperty.Register("TextChanged", typeof(bool), typeof(ViewModel), new PropertyMetadata(false,OnTextChanged));
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                //your logic after 1 second
                _functionProvidersView.Refresh();
            }
        }
