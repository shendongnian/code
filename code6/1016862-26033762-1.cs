    public class UseMeDataContext:System.Data.Linq.DataContext
	
    {
    ...
    }
    
    UseMeDataContext db ;
    if (newDatabaseVersionFlag)
    {
        db = ((System.Data.Linq.DataContext) new Data.DatabaseContext(connectionString));
    }
    else
    {
        db  = ((System.Data.Linq.DataContext) new Data2.DatabaseDataContext(connectionString));
        
    }
    
    db.Something item2 = UseMeContext.Somethings.SingleOrDefault(e => e.Id == id);
        item2.Sth =  (TypeOf(item2.sth))5; // May or May not Need typing
        item2.Sth2 = "sample code";
