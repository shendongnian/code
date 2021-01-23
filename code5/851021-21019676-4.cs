    private ISubject<MyObject,MyObject> objectNotification =
        Subject.Synchronized(new Subject<MyObject>());
    ...
    private void parseMethod(object sender, FileSystemEventArgs e)
    {
        MyObject parsedFile = new MyObject(e.FullPath);
        File.Delete(e.FullPath);
        objectNotification.OnNext(parsedFile);
    }
