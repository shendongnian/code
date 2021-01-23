    private readonly _uowLock;
    
    public Class()
    {
        _uowLock = new object();
        
        // run any background threads
        
        // loading data in main thread
        LoadCollection();
    }
    
    private void LoadCollection()
    {
        // obtain lock
        lock (_uowLock)
        {
            Collection  = _uow.Contacts.Getall().Select(s=> new ViewModel(s,_uow)).Take(200).ToList();
        }
    }
    
    // this should be called from background worker
    private void LoadAllCollection()
    {
        // obtain lock
        lock (_uowLock)
        {
            AllColloection  =_uow.Contacts.Getall().Select(s=> new ViewModel(s,_uow)).ToList();
        }
    }
