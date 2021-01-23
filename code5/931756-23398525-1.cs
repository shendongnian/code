    var installTask = Task.Run(async () =>
    {
      var tasks = new List<Task>();
      foreach (var module in Modules)
      {
        var installModule = module as IInstallModule;  // copy closure variable
        if (installModule == null)
          continue;
        var ip = new Progress<InstallProgress>();
        tasks.Add(installModule.InstallAsync(targetMachine.MachineName, ip));
      }
    });
