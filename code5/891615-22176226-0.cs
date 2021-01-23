    public Task FlushLog(string filePath)
    {
      var task = new Task(
      () => 
      while (true)
      {
         try
         {
            var file = new FileStream(filePath, FileMode.OpenOrCreate, 
                                      FileAccess.ReadWrite, FileShare.Read));
            WriteLogToFileInTheUsualWay(file);
            file.Close();
            file.Dispose();
            exit;
         }
         catch (UnauthorizedAccessException exception)
         {
            // Sleep randomly and try again
            Thread.Sleep(new Random(DateTime.Now.Milliseconds).Next(1000));
         }
      }
      );
      task.Start();
      return task;
    }
