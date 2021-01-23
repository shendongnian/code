         public static async Task ConfigureSimulatorAsync()
        {
            var proxyFile = await Package.Current.InstalledLocation.GetFileAsync(@"data\WindowsStoreProxy.xml");
            await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
        }
        
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await MainPage.ConfigureSimulatorAsync();
        }
