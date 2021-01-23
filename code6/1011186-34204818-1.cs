      List<Task> tasksToWait = new List<Task>();
    for (var i = 1; i < manga.ContentInfo.ContentPages; i++)
            {
    taskToWait.Add(Task.Run(()=>SaveMangaPage(i));
    }
    await Task.WhenAll(tasksToWait );
    await ProcessSaved();
