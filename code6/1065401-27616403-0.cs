    Task delayedTask = Task.Delay(TimeSpan.FromMinutes(5));
    Task workerTask = Task.Factory.StartNew(() =>
    {
         Aspose.Words.Document doc = new Aspose.Words.Document(inputFileName);
         doc.Save(Path.ChangeExtension(inputFileName, ".pdf"));
    });
    await Task.WhenAny(delayedTask, workerTask);
