    class PersonRepositoryXML: IPersonRepository
    {
        public IPerson GetPerson(int id)
        {
            //Fetch from XML
        }
    }
    public interface IPersonRepository
    {
        IPerson GetPerson(int id);
    }
    // a dependent class
    class SomeDependentClass {
        public SomeDependentClass(IPersonRepository repository) {
             this.repository = repository;
        }
        public void Foo() {
             var person = repository.GetPerson(10);
             // do smth to the person :)
        }
    }
