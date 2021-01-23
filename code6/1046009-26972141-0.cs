    interface IEntity
    {
    	string Name { get; set; }
    }
    
    class FooEntity : IEntity
    {
    	public string Name { get; set; }
    	
    	public FooEntity()
    	{
    		Name = "foo";
    	}
    }
    
    interface ILetter<T> where T:IEntity
    {
    	string EntityMetadata { get; set; }
        List<T> GetRecords();
    }
    
    
    abstract class AbstractLetter<T> : ILetter<T> where T:IEntity
    {
     	public abstract string EntityMetadata { get; set; }
        public abstract List<T> GetRecords();
    }
    
    class JobLetter : AbstractLetter<FooEntity>
    {
    	public override string EntityMetadata { get; set; }
        public override List<FooEntity> GetRecords() { return null; }
    	
    	public JobLetter()
    	{
    		var entity = new FooEntity();
    		EntityMetadata = entity.Name;
    	}
    }
    
    List<T> CreateLetterList<T, K>() where T : AbstractLetter<K>, new() where K : IEntity
    {
    	return new List<T> { new T(), };
    }
    
    void Main()
    {
    	var jobLetterList = CreateLetterList<JobLetter, FooEntity>();
    	foreach (var letter in jobLetterList)
    	{
    		Console.WriteLine(letter.EntityMetadata);
    	}
    }
