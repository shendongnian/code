    public DelegateCommand StartChromeCommand = new DelegateCommand(OnStartChrome);
    
    private void OnStartChrome()
    {
       var process = new Process(new ProcessStartInfo {Arguments = @"http://www.google.com"});
       process.Start();
    }
