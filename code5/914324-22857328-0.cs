    void OnRegister(object sender, RoutedEventArgs e)
    {
        RegisterAsync().Start();
    }
    
    async Task RegisterAsync() {
    	await PrintManager.ShowPrintUIAsync();	
    }
