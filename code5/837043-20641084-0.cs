    public event EventHandler<_File> OnFileReceivedEvent;
 
    public void AddFile(_File file)
    { 
        // ...
        // to raise event
        var handler = OnFileReceivedEvent;
        if (handler != null)
            handler(this, file);
    }
