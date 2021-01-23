    private CancellationTokenSource _canceller;
    private async void goButton_Click(object sender, EventArgs e)
    {
        goButton.Enabled = false;
        stopButton.Enabled = true;
        _canceller = new CancellationTokenSource();
        await Task.Run(() =>
        {
            do
            {
                Console.WriteLine("Hello, world");
                if (_canceller.Token.IsCancellationRequested)
                    break;
                    
            } while (true);
        });
        _canceller.Dispose();
        goButton.Enabled = true;
        stopButton.Enabled = false;
    }
    private void stopButton_Click(object sender, EventArgs e)
    {
        _canceller.Cancel();
    }
