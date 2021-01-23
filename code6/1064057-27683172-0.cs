    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
       base.OnNavigatedTo(e);
       App.PersonalizedViewModel.favorites.Clear();
       DataContext = App.PersonalizedViewModel;
       // this.Loaded += new RoutedEventHandler(MainPage_Loaded);
 
       if (!App.PersonalizedViewModel.IsDataLoaded)
       {
           App.PersonalizedViewModel.LoadData();
       }
    }
