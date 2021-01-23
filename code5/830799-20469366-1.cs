     public void Insert(PM_LPO lpo, LPO_Transaction lpo_transaction)
    {
        using (TransactionScope transaction = new TransactionScope())
        {
             context1.SaveChanges(false);
             context2.SaveChanges(false);
             
            _context1.LPO.Add(lpo);
            _context2.LPO_Transaction.Add(lpo_transaction);       
            transaction.Complete();
       
           context1.AcceptAllChanges();
           context2.AcceptAllChanges();
        }
    }
