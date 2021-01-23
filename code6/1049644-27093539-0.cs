    internal void ExecuteLongProcedure(int param1, int param2, int param3,
        CancellationToken cancellationToken, IProgress<string> progress)
    {       
      //Start doing work
      if (progress != null)
        progress.Report("Work Started");
      while (true)
      {
        //Mid procedure progress report
        if (progress != null)
          progress.Report("Bath water n% thrown out");
        cancellationToken.ThrowIfCancellationRequested();
      }
      //Exit message
      if (progress != null)
        progress.Report("Done and Done");
    }
