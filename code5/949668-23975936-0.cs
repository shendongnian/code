    interface IRepository<T> where T : class, IGetAllRecords
    {
    	Task<List<T>> GetAllRecordsAsync(EntitiesNew source);
    }
    
    public class Repository<T> : IRepository<T> where T : class, IGetAllRecords
    {
    	public async Task<List<T>> GetAllRecordsAsync(EntitiesNew source)
    	{
    	    return await Task.FromResult<List<T>>(null);
    	}
    }
    
    public class Foo : IGetAllRecords {}
    
    public class FooRepository : Repository<Foo>
    {
    }
