    public class Persons
    {
        public ITelecoms Telecom {get;set;}
    }
    Person p1 = new Person {Telecom = new Phoneline()};
    Person p2 = new Person {Telecom = new PhonelineAndBroadband()};
    
    List<Person> persons = new List<Person>{p1, p2};
    
    persons.ForEach(r=> r.Telecom.Price());
