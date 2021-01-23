    private async void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (State.Value > 0)
      {
        var progress = new Progress<int?>(value =>
        {
          WorkingBar.IsIndeterminate = (value == null);
          if (value != null)
            WorkingBar.Value = value.Value;
        });
        await Task.Run(() => doWork(progress));
        Task.Run(SqlAStart);
      }
      ...
    }
    private void SqlAStart(IProgress<int?> progress)
    {
      ServerTask = Task.Run(HttpSrv.listen);
      ...
    }
    private void doWork(IProgress<int?> progress)
    {
      if (progress != null)
        progress.Report(null);
      ...
    }
