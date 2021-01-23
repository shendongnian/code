    public void DoSomething()
    {
        using(DataContext ctx = new DataContext(Uri))
        {
             //do something with the context and call SaveChanges()
        }
    }
