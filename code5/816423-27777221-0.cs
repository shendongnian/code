        public PageFunction1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("page2.xaml",UriKind.RelativeOrAbsolute));
        }
    
