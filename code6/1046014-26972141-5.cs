    interface ILetter<out T> where T:IEntity
    {
    	string EntityMetadata { get; set; }
        IEnumerable<T> GetRecords();
    }
    
    
    abstract class AbstractLetter<T> : ILetter<T> where T:IEntity
    {
     	public abstract string EntityMetadata { get; set; }
        public abstract IEnumerable<T> GetRecords();
    }
    class JobLetter : AbstractLetter<FooEntity>
    {
    	public override string EntityMetadata { get; set; }
        public override IEnumerable<FooEntity> GetRecords() { return null; }
    	
    	public JobLetter()
    	{
    		var entity = new FooEntity();
    		EntityMetadata = entity.Name;
    	}
    }
	
	class SubsidyLetter : AbstractLetter<FooEntity2>
    {
    	public override string EntityMetadata { get; set; }
        public override IEnumerable<FooEntity2> GetRecords() { return null; }
    	
    	public SubsidyLetter()
    	{
    		var entity = new FooEntity2();
    		EntityMetadata = entity.Name;
    	}
    }
    void Main()
    {
		var jobLetterList = CreateLetterList<JobLetter, FooEntity>();
		var subsidyLetterList = CreateLetterList<SubsidyLetter, FooEntity2>();
		var mergedList = new List<ILetter<IEntity>>();
		
		mergedList.Add(jobLetterList[0]);
		mergedList.Add(subsidyLetterList[0]);
					
    	foreach (var letter in mergedList)
    	{
    		Console.WriteLine(letter.EntityMetadata);
    	}
    }
