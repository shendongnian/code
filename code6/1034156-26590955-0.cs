    public class Job
    {
       private DateTime _startDate;
    
       public void Job()
       {
         _startDate = DateTime.UtcNow;
       }
    
       public void Job(DateTime dt)
       {
         // check DateTime kind, this could be source of a bug
         if(dt.Kind != DateTimeKind.Utc) throw new ...
         _startDate = dt;
       }
    }
