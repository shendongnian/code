    private async Task GetCurrentCoordinateAsync()
    {
        //....
    }
    private async void btnSendSms_Click(object sender, RoutedEventArgs e)
    {
        await GetCurrentCoordinateAsync();
        // You'll get here only after the first method finished asynchronously.
        SendSms();
    }
    
