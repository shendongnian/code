    private Task<string> DoWhileShowingDialogAsync()
    {
        return Task.Run(() => DoSomethingComplex());
    } 
    
    private string DoSomethingComplex()
    {
        // wait a noticeable time
        for (int i = 0; i != 1000000000; ++i)
        ; // do nothing, just wait
    }
    
    private async void GetResult()
    {
        pd.Show();
        string result = await DoWhileShowingDialogAsync();
        pd.Close();
    }
 
