    public class Database
    {
    }
    
    public class DbCommand
    {
    }
    
    public delegate void AssignParameter(Database db, DbCommand cmd);
    
    …
    
    AssignParameter ap = delegate(Database db, DbCommand cmd)
    {
    };
