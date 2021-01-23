    public MainPage() //Your page constructor
        {
            InitializeComponent();
            this.browserControl.Loaded += SetBrowserUri;
        }
      private void SetBrowserUri(object sender, RoutedEventArgs e)
        {
            browserControl.Navigate(new Uri("http://www.bing.com"));
        }
        private void UriContentLoaded(object sender, NavigationEventArgs e)
        {
            if (MessageBox.Show("Do you want to load a second uri?", "Load again", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                browserControl.LoadCompleted -= this.UriContentLoaded; //Remove previous handler
                browserControl.LoadCompleted += this.SecondUriContentLoaded; //Add new handler
                browserControl.Navigate(new Uri("http://www.google.com"));
            }
        }
        private void SecondUriContentLoaded(object sender, NavigationEventArgs e)
        {
            MessageBox.Show("Finished loading");
        }
