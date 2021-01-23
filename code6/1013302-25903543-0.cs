    private async void _button_Click(object sender, RoutedEventArgs e)
    {
      _button.IsEnabled = false;
      var progress = new Progress<Tupe<int, int>>(update =>
      {
        _results.Text += update.Item1 + " primes between " + (update.Item2 * 1000000) +
            " and " + ((update.Item2 + 1) * 1000000 - 1) + Environment.NewLine));
      });
      await Task.Run(() => Go1(progress));
      _button.IsEnabled = true;
    }
    void Go1(IProgress<Tuple<int, int>> progress)
    {
      for (int i = 1; i < 5; i++)
      {
        int result = GetPrimesCount(i * 1000000, 1000000);
        if (progress != null)
          progress.Report(Tuple.Create(result, i));
      }
    }
