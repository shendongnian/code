    public abstract class AuditableBase 
    {
         // Feel free to modify the access modifiers of the get/set and even the properties themselves to fit your use case.
         public Guid RowGUID { get; set;}
         public Guid InsertUserGUID { get; set;}
         public Guid UpdateUserGUID { get; set;}
         public Guid DeleteUserGUID { get; set;}
         public DateTime UpdateDate { get; set;}
         public DateTime InsertDate { get; set;}
         public DateTime DeleteDate { get; set;}
         // Don't forget a protected constructor if you need it!
    }
    public class SomeModel : AuditableBase { } // This has all of the properties and methods of the AuditableBase class.
