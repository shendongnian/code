    public class PersonProfessionSpecification : ISpecification<Person>
    {
        private string[] _professions;
        public PersonProfessionSpecification(params string[] professions)
        {
            _professions = professions;
        }
        public bool Satisfied(Person person)
        {
            return _professions.Contains(person.Profession);
        }
    }
