    public interface IAuditEntity
    {
       DateTime CreateDate {get;set;}
       DateTime UpdateDate {get;set;}
    }
    public class SomeEntity : IAuditEntity
    {
       public DateTime CreateDate {get;set;}
       public DateTime UpdateDate {get;set;}
    }
