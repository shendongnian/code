    // Interface instead of concrete class
    IRepository repository;
    ...
    
    // Some way to inject a mock repo.
    public void SetRepository(IRepository repo)
    {
        this.repository = repo;
    }
    
    public int ReturnFromDB(int input)
    {
        try
        {
             return repository.method(input);
        }
        catch(RepositoryException ex)
        {
             throw new ParticularException("some message",ex);
        }
    }
