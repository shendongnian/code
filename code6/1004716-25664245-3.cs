    public ISomethingService(IFirstRepo repo1, ISecondRepo repo2, IUnitOfWork uow)
    {
    ...
    }
    public void DoSomething() 
    {
        using (IUnitOfWork uow = new NHibernateUnitOfWork())
        {
            try
            { 
                repo1.AddThis();
                repo2.GetThisOne();
                repo2.BecauseOfTheOneAboveDeleteThis();
                uow.Commit();
            }
            catch(Exception ex)
            {
               uow.RollBack();
            }
        }
    }
