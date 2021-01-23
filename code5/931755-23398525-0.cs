    public static Task<InstallCompletedResult> InstallAsync(
        this IInstallModule module, string machineName,
        IProgress<InstallProgress> progress = null)
    {
      var tcs = new TaskCompletionSource<InstallCompletedResult>();
      InstallCompletedEventHandler handler = null;
      handler = (s, e) =>
      {
        module.InstallCompleted -= handler;
        if (e.Exception != null)
          tcs.TrySetException(e.Exception);
        else
          tcs.TrySetResult(e.Result);
      };
      module.InstallCompleted += handler;
      module.Install(machineName, progress);
    }
