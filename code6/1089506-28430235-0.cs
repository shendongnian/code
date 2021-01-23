    public class SynchronousViewDatabase : IDatabase
    {
        public Task<Data> GetData()
        {
            return Task.FromResult<Data>(GetData());
        } 
    }
