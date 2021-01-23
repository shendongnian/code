    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            (this.Content as Grid).Children.Add( e.Parameter as UIElement);
            base.OnNavigatedTo(e);
        }
    }
