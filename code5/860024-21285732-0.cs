    public class MyService
    {
        public MyRepository _repos = new MyRepository();
    
        // [...]
    }
    public class MyRepository
    {
        public SqlConnection _connection = new SqlConnection("...");
    
        // [...]
    }
