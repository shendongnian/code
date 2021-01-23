    private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
                {
                    // TODO: Create an appropriate data model for your problem domain to replace the sample data
                    var myData = await GetListOfThingsFromBackend();
                    this.DefaultViewModel["Groups"] = myData;
        
                    MainViewModel viewModel = DataContext as MainViewModel;
                    if (!viewModel.IsDataLoaded)
                    {
                        viewModel.Load();
                    }
                }
