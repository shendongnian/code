    void Main()
    {
        var personList = new List<PersonSql>
        {
            new PersonSql
            {
                Id = 1,
                FirstName = "Some",
                LastName = "Person"
            }
        }.AsQueryable();
    
        var repo = new PersonRepo();
        repo.Query = personList;
    
        repo.GetById(1).Dump();
    }
    
    // Define other methods and classes here
    
    //entity base
    class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
    
    
    //common constructs
    class PersonBase<Tkey> : BaseEntity<Tkey>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    //actual entity with type of int as the id
    class PersonSql : PersonBase<int>
    {
    
    }
    
    //and so on
    class PersonNoSql : PersonBase<string>
    {
    
    }
    
    //likley you would generate these or code them based on your data source when creating your mapping classes.
    
    //repositories
    
    interface IRepository<TEntity, TKeyI>
        where TEntity : BaseEntity<TKeyI>
    {
        IQueryable<TEntity> Query {get; set;}
        TEntity GetById(TKeyI key);
        //Other Repository Methods here
    }
    
    
    abstract class RepoBase<TBaseEntity, TKeyB> : IRepository<TBaseEntity, TKeyB>
        where TBaseEntity : BaseEntity<TKeyB>
    {
        //Base Implementations Here
        public IQueryable<TBaseEntity> Query { get; set; }
        public virtual TBaseEntity GetById(TKeyB key)
        {
            throw new NotImplementedException();
        }
    }
    
    abstract class PersonRepoBase<TkeyType> : RepoBase<PersonBase<TkeyType>, TkeyType>
    {
        public override PersonBase<TkeyType> GetById(TkeyType key)
        {
            //Get a person.
            throw new NotImplementedException();
        }
    }
    
    //class PersonRepo : RepoBase<PersonNoSql, string>
    //{
    //	public override PersonNoSql GetById(string id)
    //	{
    //		throw new NotImplementedException();
    //	}
    //}
    
    class PersonRepo : RepoBase<PersonSql, int>
    {
        public override PersonSql GetById(int id)
        {
            return Query.First(x => x.Id == id);
            throw new NotImplementedException();
        }
    }
