    public interface IPersonRepository : IRepository<Person>
    {
        IQueryable<Person> GetAll { get; }
    }
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        // ...
        public IQueryable<Person> GetAll
        {
            get { return DbSet; }
        }
    }
    public class SomeBusinessLogicClass
    {
        private readonly IPersonRepository _people;
        public SomeBusinessLogicClass(IPersonRepository people)
        {
            _people = people;
        }
        public IEnumerable<Person> GetByFirstName(string name)
        {
            return _people.GetAll.Where(p => p.FirstName == name);
        }
    }
