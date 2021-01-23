    async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Busy.Visibility = System.Windows.Visibility.Visible; // Shows progress animation
        if (await SAPLogin()) // Waits for login to finish, will always be true at the moment
        {
            //await GetData(); // does things with sap
            await Task.Factory.StartNew(() => GetData(),
                CancellationToken.None,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default).Unwrap();
            Busy.Visibility = System.Windows.Visibility.Collapsed; // Hides progress animation
        }
    }
    private Task<bool> SAPLogin()
    {
        bool LoggedIn = true;
        return Task.Factory.StartNew(() =>
        {
            Backend = new BackendConfig();
            RfcDestinationManager.RegisterDestinationConfiguration(Backend);
            SapRfcDestination = RfcDestinationManager.GetDestination(MyServer);  // MyServer is just a string containing sever name
            SapRap = SapRfcDestination.Repository;
            BapiMD04 = SapRap.CreateFunction("MD_STOCK_REQUIREMENTS_LIST_API");
            BapiMD04.SetValue("WERKS", "140");
            return LoggedIn;
        }, 
        CancellationToken.None,
        TaskCreationOptions.LongRunning,
        TaskScheduler.Default);
    }
