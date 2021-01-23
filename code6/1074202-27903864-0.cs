    private static async Task DoSomethingAsync()
    {
      Progress<object> progress = new Progress<object>(item => F.ls1.Items.Add(item));
      await Task.Run(() => BackgroundWork(progress));
    }
    private static void BackgroundWork(IProgress<object> progress)
    {
      // Do background work here.
      var item = "NewItem";
      // Notify UI of progress.
      if (progress != null)
        progress.Report(item);
    }
