    string _path;
    object _lock = new object();
    volatile bool _running;
    volatile bool _cancel;
    public void OnChanged(object source, FileSystemEventArgs e)
    {   
        // waiting
        while(_running)
        {
            _cancel = true;
            Thread.Sleep(0);
        }
        // start new thread
        _cancel = false;
        _path = e.FullPath;
        (new Thread(ReadFile)).Start();
    }
    public void ReadFile()
    {
        lock(_lock)
        {
            _running = true;
            using(var reader = new FSReader(_path))
                while (!reader.EndOfStream)
                {
                    if(_cancel)
                        break;
                    PrintLine(reader.ReadLine());
                }
            _running = false;
        }
