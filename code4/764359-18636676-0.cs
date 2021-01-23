    public sealed partial class MainPage : Page
    {
        ObservableCollection<LinkItem> LinkItems {get; set;} // <---------
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HtmlParser pars = new HtmlParser();
            pars.Uri = "http://some website.something/";
            LinksItems = await pars.Parse();    //<-------------
        }
    }
