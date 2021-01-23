    public interface IDataValidator
    {
        void ValidateData();
    }
    
    public string Serialize<T>(T obj):where T:IDataValidator
    {
        obj.ValidateData();
        return Serialize(obj);
    }
    
    public T Deserialize<T>(string serializedObj):where T:IDataValidator
    {
        T obj = Deserialize(serializedObj);
        obj.ValidateData();
    }
    public class Book : IDataValidator
    {
        public string Isbn {get;set;}
    
        public Book(){}
        public Book(string isbn)
        {
            Isbn = isbn;
        }
    
        public void ValidateData()
        {
            if(string.IsNullOrEmptyOrWhiteSpace(Isbn)
                throw new ApplicationException("...");
        }
    }
