    //Feel free to ignore RepostoryEntryBase
    public class COMPANIES : RepositoryEntryBase, IRepositoryEntry
    {
        public string KEY { get; set; } //KEY	VARCHAR2(20)	N	
        public int COMPANY_ID { get; set; }   //COMPANY_ID	NUMBER(10)	N		
        public string DESCRIPTION { get; set; }//DESCRIPTION	VARCHAR2(100)	N
        public COMPANIES() : base ()
        {
            primaryKeys.Add("COMPANY_ID");
        }
    }
    public abstract class DbRepository : IDbRepository
    {
        public Dictionary<Type,IRepository> Repositories { get;set; }
        public DbRepository(){
            Repositories = new Dictionary<Type,IRepository>();
            Repositories .add(typeof(COMPANIES)),new OracleRepository<COMPANIES>());
        }
        public object Insert(object entity)
        {
            if(!(entity is IRepositoryEntry))
                throw new NotSupportedException("You are bad and you should feel bad");
            if(!Repositories.ContainsKey(entity.GetType()))
                throw new NotSupportedException("Close but no cigar");
             Dictionary[entity.GetType()].Insert(entity);
        }
    
        //You can add additional operations here:
    }
