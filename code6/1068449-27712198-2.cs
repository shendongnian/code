        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this; // You would put a ViewModel here when using MVVM design pattern
        }
        public static readonly DependencyProperty IsLandscapeProperty
            = DependencyProperty.Register("IsLandscape",
                                            typeof (bool),
                                            typeof (MainWindow));
        public bool IsLandscape
        {
            get { return (bool) GetValue(IsLandscapeProperty); }
            set { SetValue(IsLandscapeProperty, value); }
        }
        private void ChangeOrientation(object sender, RoutedEventArgs e)
        {
            this.IsLandscape = !this.IsLandscape;
        }
