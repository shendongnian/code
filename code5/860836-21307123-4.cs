    using (var context = new MyContext())
    {
        using (TransactionScope scope = new TransactionScope())
        {
            var child= new Child();
            var parentRecord = context.Parent.Find(parent.Id);
            child.Parent= parentRecord; 
            context.SaveChanges();
            scope.Complete();
        }
    }
