    private async void ButtonClicked()
    {
      var progress = new Progress<int>(update =>
      {
        // Apply "update" to the UI
      });
      var result = await Task.Run(() => DoWork(progress));
      if (result) MessageBox.Show("Success!");
    }
    private static bool DoWork(IProgress<int> progress)
    {
      for (int i = 0; i != 5; ++i)
      {
        if (progress != null)
          progress.Report(i);
        Thread.Sleep(1000);
      }
      return true;
    }
