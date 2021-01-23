    volatile bool _cancel;
    Mutex _mutext = new Mutex(false);
    public void OnChanged(object source, FileSystemEventArgs e)
    {
        _cancel = true;
        _mutex.WaitOne();
        // start new thread
        _cancel = false;
        _mutex.ReleaseMutex();
        (new Thread(ReadFile)).Start(e.FullPath);
    }
    public void ReadFile(string path)
    {
        _mutex.WaitOne();
        using(var reader = new FSReader(path))
            while (!reader.EndOfStream)
            {
                if(_cancel)
                    break;
                PrintLine(reader.ReadLine());
            }
        _mutex.ReleaseMutex();
    }
