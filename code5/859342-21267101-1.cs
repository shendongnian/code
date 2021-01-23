    void initForm()
    {
      if(File.Exists(path))
      {
        // Update form
      }
      else
      {
        var watcher = new FileSystemWatcher(path, ".txt");
        watcher.Created += (sender, e) =>
        {
          if (e.ChangeType == WatcherChangeTypes.Created)
            initForm();
        };
      }
    }
