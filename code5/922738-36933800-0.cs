    var listOfActions = new List<Action>();
    foreach (var file in files)
    {
        var localFile = file;
        // Note that we create the Task here, but do not start it.
        listOfTasks.Add(new Task(() => blobBlock.UploadFromFileAsync(localFile, FileMode.Create)));
    }
 
    var options = new ParallelOptions {MaxDegreeOfParallelism = 5};
    Parallel.Invoke(options, listOfActions.ToArray());
