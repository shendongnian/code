    public class BaseErase
    {
        protected string ConnectionString
        {
            get; private set;
        }
    
        public BaseErase(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
    
    public class ToEraseClass : BaseErase
    {
        public ToEraseClass(connectionString) : base(connectionString) 
        {}
    
        public void GetData()
        {
            Console.WriteLine(ConnectionString);
        }
    }
