    public MyController(IUnitOfWorkFactory workFactory)
    {
        this.workFactory = workFactory;
    }
    
    public ActionResult DoSomething()
    {
        using(var uow = workFactory.Create())
        {
            //do work
        }
    }
