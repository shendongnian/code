    public class PersonRepository: RepositoryBase<Person>, IPersonRepository
        {
        public PersonRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IPersonRepository : IRepository<Person> // Person will be your POCO class
    {
    }
