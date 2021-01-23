    public void AServiceMethod()
    {
        using (var context = contextProvider.CreateContext())
        {
            // call some domain operations, which use repositories
            
            // commit 
        }
    }
