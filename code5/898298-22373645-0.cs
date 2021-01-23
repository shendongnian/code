    private bool _isRunning = false;
    public async void GetText(object o)
    {
        await Task.Factory.StartNew(() =>
        {
            _isRunning = true;
            CommandManager.InvalidateRequerySuggested(); 
            // code
            _isRunning = false;
            CommandManager.InvalidateRequerySuggested();
        });
    }
