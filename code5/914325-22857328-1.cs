    void OnRegister(object sender, RoutedEventArgs e)
    {
        RegisterAsync();
    }
    
    async void RegisterAsync() {
    	await PrintManager.ShowPrintUIAsync();	
    }
