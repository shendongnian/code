    abstract class AbstractLetter: ILetter<IEntity>
    {
        public abstract string EntityMetadata { get; set; }
        public abstract List<IEntity> GetRecords();
    }
    
    class JobLetter<T> : AbstractLetter where T : IEntity, new()
    {
        public override string EntityMetadata { get; set; }
        public override List<IEntity> GetRecords() { return null; }
    
        public JobLetter()
        {
            var entity = new T();
            EntityMetadata = entity.Name;
        }
    }
    
    class SubsidyLetter<T> : AbstractLetter where T : IEntity, new()
    {
        public override string EntityMetadata { get; set; }
        public override List<IEntity> GetRecords() { return null; }
    
        public SubsidyLetter()
        {
            var entity = new T();
            EntityMetadata = entity.Name;
        }
    }
    List<T> CreateLetterList<T>() where T : AbstractLetter, new()
    {
        return new List<T> { new T(), };
    }
    
    void Main()
    {
        var jobLetterList = CreateLetterList<JobLetter<FooEntity>>();
    	var subsidyLetterList = CreateLetterList<SubsidyLetter<FooEntity2>>();
    	
    	var mergedList = new List<AbstractLetter>();
    	mergedList.Add(jobLetterList[0]);
    	mergedList.Add(subsidyLetterList[0]);
    	
        foreach (var letter in mergedList)
        {
            Console.WriteLine(letter.EntityMetadata);
        }
    }
