    private void Button_Click(object sender, RoutedEventArgs e)
    {
       TextBoxOutput.Text = "calculating...";
       Task.Factory
        .StartNew(() => Calculate())
        .ContinueWith(t =>
        {
            TextBoxOutput.Text = t.Result.ToString(CultureInfo.InvariantCulture);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private int Calculate()
    {
       Thread.Sleep(2000); //--similate working....
       return Environment.TickCount ^ 43;
    }
