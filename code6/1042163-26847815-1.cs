    using (TransactionScope scope = new TransactionScope())
    {
        //Do something with DBcontext - Update existing
        //Save Changes
        context.SaveChanges(false);
        //Do something else with DBcontext - Delete old
        //Save Changes
        context.SaveChanges(false);
        //Do something else with DBcontext - Insert new
        //Save Changes
        context.SaveChanges(false);
        //if we get here things are looking good.
        scope.Complete();
        context.AcceptAllChanges();
    }
