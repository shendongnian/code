    TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable });
    try
    {
        using (scope)
        {
            using (OrdersDbContext ctx = new OrdersDbContext())
            {
                ctx.Connection.Open();
                //Do something with DBcontext - Update existing
                //Save Changes
                ctx.SaveChanges(false);
                //Do something else with DBcontext - Delete old
                //Save Changes
                ctx.SaveChanges(false);
                //Do something else with DBcontext - Insert new
                //Save Changes
                ctx.SaveChanges(false);
                //if we get here things are looking good.
                scope.Complete();
                ctx.AcceptAllChanges();
            }
            scope.Complete();
        }
    }
    catch (TransactionAbortedException ex)
    {
        ErrorLogger.LogException();
    }
    catch (ApplicationException ex)
    {
        ErrorLogger.LogException();
    }
