    public abstract class AuditableBase 
    {
         public Guid RowGUID { get; protected set;}
         public Guid InsertUserGUID { get; protected set;}
         public Guid UpdateUserGUID { get; protected set;}
         public Guid DeleteUserGUID { get; protected set;}
         public DateTime UpdateDate { get; protected set;}
         public DateTime InsertDate { get; protected set;}
         public DateTime DeleteDate { get; protected set;}
         // Don't forget a protected constructor if you need it!
    }
