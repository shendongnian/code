    Action _cancelWork;
    private int DoWork(int limit, CancellationToken token, IProgress<int> progressReport)
    {
        var progress = 0;
        for (int i = 0; i < limit; i++)
        {
            progressReport.Report(progress++);
            Thread.Sleep(2000); // simulate task
            token.ThrowIfCancellationRequested();
        }
        return limit;
    }
    private async void StartButton_Click(object sender, RoutedEventArgs e)
    {
        this.StartButton.IsEnabled = false;
        this.StopButton.IsEnabled = true;
        try
        {
            var cancellationTokenSource = new CancellationTokenSource();
            this._cancelWork = () => 
            {
                this.StopButton.IsEnabled = false;
                cancellationTokenSource.Cancel();
             };
            var limit = 10;
            var token = cancellationTokenSource.Token;
            var progressReport = new Progress<int>((i) => 
                this.TextBox.Text = (100 * i / (limit-1)).ToString() + "%");
            await Task.Run(() =>
                DoWork(limit, token, progressReport), 
                token);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        this.StartButton.IsEnabled = true;
        this.StopButton.IsEnabled = false;
    }
    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        this._cancelWork();
    }
 
