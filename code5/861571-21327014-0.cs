    private async void Start(object sender, RoutedEventArgs e)
    {
        try
        {
            await Task.Run(() =>
            {
                int progress = 0;
                for (; ; )
                {
                    System.Threading.Thread.Sleep(1);
                    progress++;
                    Logger.Info(progress);
                }
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
