    async void button_click(object sender, RoutedEventArgs e)
    {
        // prepare the array
        // ...
        var tcs = new TaskCompletionSource<object>();
        var timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0,0,5);
        timer.Tick += (_, __) => tcs.SetResult(Type.Missing);
        timer.Start();
        try
        {
            for (var i = 0; i < 100; i++)
            {
                image1.Source = arr[i];
                await tcs.Task;
                tcs = new TaskCompletionSource<object>();
            }
        }
        finally
        {
            timer.Stop();
        }
    }
