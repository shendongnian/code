    public void Insert(PM_LPO lpo, LPO_Transaction lpo_transaction)
    {
        using (TransactionScope transaction = new TransactionScope())
        {
             context1.ObjectContext.SaveChanges(false);
             context2.ObjectContext.SaveChanges(false);
             _context1.LPO.Add(lpo);
             _context2.LPO_Transaction.Add(lpo_transaction);       
             transaction.Complete();
             context1.ObjectContext.AcceptAllChanges();
             context2.ObjectContext.AcceptAllChanges();
        }
    }
