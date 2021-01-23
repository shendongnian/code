    using (TransactionScope scope = new TransactionScope())
    {
        var child= new Child();
        child.Parent= parent;
        DataContext.Parent.Add(parent); 
        DataContext.Entry(parent).State = EntityState.Modified;
        DataContext.SaveChanges();
        scope.Complete();
    }
