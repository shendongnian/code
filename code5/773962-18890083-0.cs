    private async Task<ObservableCollection<MyEntity>> LoadData(ParamData param)
    {
        ServiceClient svc = new ServiceClient();
        int results = 0;
        // Set-up parameters
        myParams = BuildParams(param);
        // Call a count function to see how much data we're talking about
        // This call should be relatively quick
        var counter = Task.Factory.StartNew(() =>
        {
            results = svc.GetResultCount(myParams);
        });
        var returnTask = counter.ContinueWith((task) =>
        {
            if (results <= 10000 ||
                (MessageBox.Show("More than 10000 results, still retrieve data?"), MessageBoxButton.YesNo) == MessageBoxResult .Yes))
            {
                return svc.Search(myParams);
            }
        });
        return returnTask.Result;
    }
