        public MainWindow()
        {
            InitializeComponent();
            this.AddHandler(EventManagement.ChangeViewEvent, new RoutedEventHandler(SomeControl_ChangeView));
        }
        private void SomeControl_ChangeView(object sender, RoutedEventArgs routedEventArgs)
        {
        }
