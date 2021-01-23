    public class CurrentDateTimeProvider : IDateTimeProvider
    {
       public DateTime Now 
       {
         get { return DateTime.Now; }
       }
    }
