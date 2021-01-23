    public Class()
    {
        // run any background threads
        
        // loading data in main thread
        LoadCollection();
    }
    private void LoadCollection()
    {
        Collection  = new UnitOfWork().Contacts.Getall().Select(s=> new ViewModel(s,_uow)).Take(200).ToList();
    }
    
    // this should be called from background worker
    private void LoadAllCollection()
    {
        AllColloection  = new UnitOfWork().Contacts.Getall().Select(s=> new ViewModel(s,_uow)).ToList();
    }
