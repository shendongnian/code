    var listOfTasks = new List<Task>();
    foreach (var file in files)
    {
        var localFile = file;
        // Note that we create the Task here, but do not start it.
        listOfTasks.Add(new Task(async () => await blobBlock.UploadFromFileAsync(localFile, FileMode.Create)));
    }
    await Tasks.StartAndWaitAllThrottledAsync(listOfTasks, 5);
