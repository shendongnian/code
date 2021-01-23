    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IUnitOfWork unitOfWork;
        public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            this.personRepository = personRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Person> SearchPersonByCity(string city)
        {
            var persons = personRepository.Get(p => p.City == city);
            return persons;
        }
    }
