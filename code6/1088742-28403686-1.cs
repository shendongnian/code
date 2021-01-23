    m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
    m_Watcher.Created += new FileSystemEventHandler(OnChanged);
    m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
    m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
    void OnChanged(object sender, FileSystemEventArgs e)
    void OnRenamed(object sender, RenamedEventArgs e)
