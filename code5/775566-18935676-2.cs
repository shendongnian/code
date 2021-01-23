    public partial class Preview : PhoneApplicationPage
    {
        public Preview()
        {
            InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                if (NavigationContext.QueryString.ContainsKey("url") &&
                    Uri.IsWellFormedUriString(NavigationContext.QueryString["url"], UriKind.Absolute))
                {
                    webBrowser.Navigate(new Uri(NavigationContext.QueryString["url"], UriKind.Absolute));
                }
                else
                {
                    // TODO: Handle url parameter exception
                }
            };
        }
    }
