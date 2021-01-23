    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public int? MotherId { get; set; }
        public int? FatherId { get; set; }
    }
    
    public Class RelationFinder
    {
        Public Person GetMother(IEnumerable<Person> people, Person child)
        {
            return people.FirstOrDefault(p=>p.Id = child.MotherId);
        }
    
        Public Person GetFather(...
    
        Public IEnumerable GetChildern(...
    }
