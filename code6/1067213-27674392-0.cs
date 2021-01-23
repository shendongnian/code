    var musicQueueTuples = music.Select((m, i) => new {Music = m, QueueItem = lstQueue[i]})
        .ToList();
    // Which now allows us to use LINQ to project the tasks:
    var downloadTasks = musicQueueTuples.Select(
           mqt => Task.Factory.StartNew(
             () => DownloadAudio(mqt.Music, mqt.QueueItem))).ToArray();
    Task.Factory.ContinueWhenAll(downloadTasks, (tasks) => ...
