    var musicQueueTuples = music.Zip(lstQueue, (m, q) => new {Music = m, QueueItem = q})
        .ToList();
    // Which now allows us to use LINQ to project the tasks:
    var downloadTasks = musicQueueTuples.Select(
           mqt => Task.Factory.StartNew(
             () => DownloadAudio(mqt.Music, mqt.QueueItem))).ToArray();
    Task.Factory.ContinueWhenAll(downloadTasks, (tasks) => ...
