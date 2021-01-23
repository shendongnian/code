    public interface IPerson {
        string Name { get; set; }
    }
    public interface IPersonExtended : IPerson {
        List<IPerson> Contacts { get; set; }
    }
    [DataContract]
    public class Person : IPerson {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class PersonExtended : Person, IPersonExtended {
        [DataMember]
        public List<IPerson> Contacts { get; set; }
        public PersonExtended() {
            Contacts = new List<IPerson>();
        }
    }
    [ServiceContract]
    public interface IMyService {
        [OperationContract]
        IList<PersonExtended> GetAllPeople();
    }
    public class MyService : IMyService
    {
        private IList<PersonExtended> _people;
        public MyService() {
            _people = new IList<PersonExtended>();
        }
        public IList<PersonExtended> GetAllPeople() {
            return _people
        }
    }
