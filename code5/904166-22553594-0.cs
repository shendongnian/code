    public class Logic {
        private readonly IRepository<Person> _personRep;
        public Logic()
        {
            _personRep = new Repository<Person>(new GenericContext());
        }
    }
