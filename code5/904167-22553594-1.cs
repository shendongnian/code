    public class Logic {
        private readonly IRepository<Person> _personRep;
        public Logic(IRepository<Person> personRep)
        {
            _personRep = personRep;
        }
    }
