    using (var context = new MyContext())
    {
        using (TransactionScope scope = new TransactionScope())
        {
            var child= new Child();
            child.Parent= parent;
            context.Parent.Add(parent); 
            context.Entry(parent).State = EntityState.Modified;
            context.SaveChanges();
            scope.Complete();
        }
    }
