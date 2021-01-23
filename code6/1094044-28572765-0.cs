    public class PersonNamedOlderThanSpecification : CompositeSpecification<Person>
    {
        private string name;
        private int age;
    
        public PersonNamedOlderThanSpecification(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    
    
        public override bool IsSatisfiedBy(Person entity)
        {
            return (entity.Name.Contains(this.name)) && (entity.Age > age);
        }
    }
