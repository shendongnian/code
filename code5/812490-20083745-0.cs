    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var p3 = new Page3(e.Parameter);
            // do something
            base.OnNavigatedTo(e);
        }
    }
    public sealed partial class Page3 : Page
    {
        public Page3(object parameter)
            : base()
        {
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();
        }
    }
