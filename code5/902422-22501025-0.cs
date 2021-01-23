        public SomeWindow()
        {
            Loaded += SomeWindow_Loaded;
        }
        private void SomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitTimer();
        }
