    public static IObservable<FileChangedEvent> ObserveFolderChanges(string path, string filter, TimeSpan throttle)
    {
        return Observable.Using(
            () => new FileSystemWatcher(path, filter) { EnableRaisingEvents = true },
            fileSystemWatcher => CreateSources(fileSystemWatcher)
                .Merge()
                .GroupBy(c => c.FullPath)
                .SelectMany(fileEvents => fileEvents
                    .Throttle(throttle)
                    .Where(e => !e.IsFileDeleted)));
    }
