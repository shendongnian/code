    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        var title = NavigationContext.QueryString["title"];
        (DataContext as ImagePageViewModel).Load(title);
    }
