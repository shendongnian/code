    public abstract class DomainEntity
    {
        private IValidator validator;
        public bool IsValid
        {
            get { return validator.IsValid; }
        }
        public ValidationResult Validate()
        {
            return validator.Validate();
        }
    }
    public class Person : DomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person() : base(new PersonValidator())
    }
    public class PersonValidator() : AbstractValidator<Person>
    {
        public PersonValidator()
        {
             ... validation logic
        }
    }
