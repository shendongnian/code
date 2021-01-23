        public Donate()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var customMessageBox = new CustomMessageBox()
            {
                LeftButtonContent = "Ok",
                RightButtonContent = "Cancel",
                Content = new TextBlock()
                {   // All TextBlock (or other control) properties are work here
                    Text = "This Will Take You Out Of The App And Forward You To Our Contribution Website!",
                    TextWrapping = TextWrapping.Wrap
                }
            };
            customMessageBox.Dismissed += (sender, args) =>
            {
                if (args.Result == CustomMessageBoxResult.LeftButton)
                {
                    // Action when "ok" pressed
                    donation.Source = new Uri("http://mobiledonation.vzons.com/ArvindKejriwal", UriKind.Absolute);
    
                    donation.Loaded += (object sender, RoutedEventArgs e) =>
                    {
                        donation.Navigate(new Uri("http://mobiledonation.vzons.com/ArvindKejriwal", UriKind.Absolute));
                    };
                }
                else if (args.Result == CustomMessageBoxResult.RightButton)
                {
                    // Action when "cancal" pressed, optional
                }
                else
                {
                    // Action when back key pressed, optional
                }
            };
            customMessageBox.Show();
        }
