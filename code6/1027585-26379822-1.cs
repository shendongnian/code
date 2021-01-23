    public class Person : QueryTable<Person>
    {
        public string Name { get; set; }
    }
    public class User : QueryTable<User>
    {
        public string UserName { get; set; }
    }
    public abstract class QueryTable
    {
        // TODO: Write as much as you can, here.
        
        protected static List<T> SelectAll<T>()
        {
            // ...
        }
    }
    public abstract class QueryTable<T> : QueryTable
    {
        public static List<T> SelectAll()
        {
            return QueryTable.SelectAll<T>();
            // Note: You could just implement this inline, here.
        }
        
        // TODO: Put stuff that is specific to T, here.
    }
