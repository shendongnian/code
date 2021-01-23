    public class PhoneApplicationPage : Page
    {
     // content
    }
    public class Page : UserControl
    {
        public NavigationCacheMode NavigationCacheMode { get; internal set; }
        public NavigationContext NavigationContext { get; }
        public NavigationService NavigationService { get; }
        public string Title { get; set; }
        protected virtual void OnFragmentNavigation(FragmentNavigationEventArgs e);
        protected virtual void OnNavigatedFrom(NavigationEventArgs e);
        protected virtual void OnNavigatedTo(NavigationEventArgs e);
        protected virtual void OnNavigatingFrom(NavigatingCancelEventArgs e);
    }
