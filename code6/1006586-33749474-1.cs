        public static async Task ConfigureSimulatorAsync(string filename)
        {
            StorageFile proxyFile = await Package.Current.InstalledLocation.GetFileAsync("data\\" + filename);
            await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
        }
        
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await MainPage.ConfigureSimulatorAsync("WindowsStoreProxy.xml");
        }
        
