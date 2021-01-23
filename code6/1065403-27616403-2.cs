    Task delayedTask = Task.Delay(TimeSpan.FromMinutes(5));
    Task workerTask = Task.Factory.StartNew(() =>
    {
         Aspose.Words.Document doc = new Aspose.Words.Document(inputFileName);
         doc.Save(Path.ChangeExtension(inputFileName, ".pdf"));
    });
    if (await Task.WhenAny(delayedTask, workerTask) == delayedTask)
    {
       // We got here because the delay task finished before the workertask.
    }
    else
    {
       // We got here because the worker task finished before the delay.
    }
