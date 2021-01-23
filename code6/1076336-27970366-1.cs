      public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
     	    List<Page> MyPages = new List<Page>();
            MyPages.Add(new DisplayNumberPage());
            MyPages.Add(new DisplayNumberPage());
            MyPages.Add(new DisplayNumberPage());
            MyPages.Add(new DisplayNumberPage());
            MyPages.Add(new DisplayNumberPage());
            OptionsList.ItemsSource = MyPages;
        }
        int Index = 1;
        private void GroupItemFrame_Loaded(object sender, RoutedEventArgs e)
        {
            Frame MyFrame = sender as Frame;
            MyFrame.Navigate(typeof(DisplayNumberPage), Index);
            Index++;
        }
    }
