    private SemaphoreSlim _mutex = new SemaphoreSlim(1);
    async void button_Click(object sender, RoutedEventArgs e)
    {
      await Task.Run(async () =>
      {
        await _mutex.WaitAsync();
        try
        {
          Console.WriteLine("start");
          Thread.Sleep(5000);
          Console.WriteLine("end");
        }
        finally
        {
          _mutex.Release();
        }
      });
    }
