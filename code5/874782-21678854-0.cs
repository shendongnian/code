    async Task LongRunningOperation()
    {
        await Task.Delay(5000);
    }
    
    private async void SomeEvent(object sender, EventArgs e)
    {
        await LongRunningOperation();
    }
 
