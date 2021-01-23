    using (DataContext pContext = new DataContext())
    {
        using (TransactionScope transaction = new TransactionScope())
        {
            //execute commands   
 
            pContext.SaveChanges();
            transaction.Complete()
        }
    }
