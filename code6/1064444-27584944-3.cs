    public partial class Refresh : PhoneApplicationPage
    {
        public Refresh()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var j = this.NavigationService.RemoveBackEntry();
            this.Dispatcher.BeginInvoke(() => App.RootFrame.Navigate(j.Source));
            base.OnNavigatedTo(e);
        }
  
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
            base.OnNavigatedTo(e);
        }
    }
