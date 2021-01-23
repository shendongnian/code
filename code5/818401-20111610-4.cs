    public abstract class BaseClass
    {
      public string SqlColumnName {get;set;}
      public SqlDbType  SqlColumnType {get;set;}
    }
    
    public class Intclass : BaseClass
    {
       public Intclass()
       {
          base.SqlColumnType = SqlDbType.Int;
       }
    }
