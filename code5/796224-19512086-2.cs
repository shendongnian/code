    public static Tuple<FileSystemWatcher, Task> Watch(this string path, Action<string> processNewFile)
    {
        var watcher = new FileSystemWatcher(path) {EnableRaisingEvents = true};
        return
            Tuple.Create(
                watcher,
                Observable
                    .FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                        handler => watcher.Created += handler,
                        handler => watcher.Created -= handler)
                    .Select(pattern => pattern.EventArgs.FullPath)
                    .ForEachAsync(processNewFile));
    }
