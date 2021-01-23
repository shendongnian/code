    abstract class BaseService
    {
        ...
        public ICollection<ExampleRecord> GetDatabaseRecords()
        {
            using (var context = new ApplicationDbContext())
            {
                /* Your DbContext code */
            }
            return databaseRecords;
         }       
        ...
    }
