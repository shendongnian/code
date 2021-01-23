    CancellationTokenSource _cts = null;
    async void SomeCommand_Executed(object sender, RoutedEventArgs e)
    {
        if (_cts != null)
        {
            // request cancellation if already running
            _cts.Cancel();
            _cts = null;
        }
        else
        {
            // start a new operation and await its result
            try
            {
                _cts = new CancellationTokenSource();
                await Execute(this.folderContent, _cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
