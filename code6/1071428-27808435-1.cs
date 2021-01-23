    public class ExampleService : BaseService
    {
        ...
        
        public ICollection<ExampleRecord> GetRecords()
        {
            return this.GetDatabaseRecords();
        }
 
        ...
    }
