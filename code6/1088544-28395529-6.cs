    public class SimpleFluentValidationObjectValidator : IObjectValidator
    {
        public SimpleFluentValidationObjectValidator()
        {
            this.Validators = new Dictionary<Type, IValidator>();
        }
        public Dictionary<Type, IValidator> Validators { get; private set; }
        public void Validate<T>(T instance, params string[] ruleSet)
        {
            var validator = this.Validators[typeof(T)];
            if(ruleSet.Length > 0) // no ruleset option for this example
                throw new NotImplementedException();
            var result = validator.Validate(instance); 
            if(!result.IsValid)
                throw new ValidationException(MapValidationFailures(result.Errors));
        }
        public Task ValidateAsync<T>(T instance, params string[] ruleSet)
        {
            throw new NotImplementedException();
        }
        private static List<ValidationFailure> MapValidationFailures(IEnumerable<FluentValidationResults.ValidationFailure> failures)
        {
            return failures
                .Select(failure =>
                    new ValidationFailure(
                        failure.PropertyName,
                        failure.ErrorMessage,
                        failure.AttemptedValue,
                        failure.CustomState))
                .ToList();
        }
    }
