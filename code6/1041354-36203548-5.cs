    [ImplementPropertyChanged]
    public class MyAppViewModel
    {
        public NavigatorViewModel Navigator { get; set; }
        public MyAppViewModel()
        {
            Navigator = new NavigatorViewModel();
            Navigator.Navigate(new MainNavigatableViewModel());
        }
    }
