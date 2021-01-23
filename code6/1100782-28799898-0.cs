    private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
        var viewModel = DataContext as StatsViewModel;
        if (viewModel != null)
        {
            await viewModel.LoadViewModel();
        }
    } 
