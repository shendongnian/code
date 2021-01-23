        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(onLoaded);
        }
        private void onLoaded(object sender, RoutedEventArgs e)
        {
             cmbx.IsDropDownOpen = true;
             cmbx.IsDropDownOpen = false;
        }
