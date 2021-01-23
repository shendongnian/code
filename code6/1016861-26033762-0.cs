    public class UseMeDataContext:DbContext
    {
    ...
    }
    
    if (newDatabaseVersionFlag)
    {
        UseMeDataContext = ((DbContext) new Data.DatabaseContext(connectionString));
    }
    else
    {
        UseMeContext  = ((DbContext) new Data2.DatabaseDataContext(connectionString));
        
    }
    
    UseMeContext.Something item2 = UseMeContext.Somethings.SingleOrDefault(e => e.Id == id);
        item2.Sth =  (TypeOf(item2.sth))5; // May or May not Need typing
        item2.Sth2 = "sample code";
