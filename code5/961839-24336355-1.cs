    public class PersonNameSpecification : ISpecification<Person>
    {
        private string _name;
        public PersonNameSpecification(string name)
        {
            _name = name;
        }
        public bool Satisfied(Person person)
        {
            return person.Name == _name;
        }
    }
