    var block = new ActionBlock<string>(folderName => 
    {
        UploadFolder(folderName);
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5 });
    
    foreach (var folderName in GetFolderNames())
    {
        block.Post(folderName);
    }
    
    block.Complete();
    await block.Completion;
