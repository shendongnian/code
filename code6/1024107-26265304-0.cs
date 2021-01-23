    using (var ts = new TransactionScope())
    {
        if (this.HasConcurrencyIssues()) {
            // can't save, exit out of save code
            return;
        }
    
        using (EntityContext context = new EntityContext()) {
            this.SaveStuff(context);
            context.SaveChanges();
        }
    
        ts.Complete();
    }
