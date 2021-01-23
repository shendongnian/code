    public abstract class Validator<T>
        : IValidatableObject 
    {
        public T Value { get; }
        public abstract IEnumerable<ValidationResult> 
              Validate(ValidationContext validationContext);
    }
