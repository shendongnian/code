    CancellationTokenSource _cts = null;
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_cts != null)
        {
            _cts.Cancel();
            _cts = null;
        }
        else
        {
            try
            {
                _cts = new CancellationTokenSource();
                await DoUIThreadWorkAsync(_cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
