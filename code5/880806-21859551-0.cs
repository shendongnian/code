    public class StudentRegistered<TS, TId> where TS : Person<TId>
    {
      public TId StudentId {get; set;}
      public int EventId {get; set;}
    }
