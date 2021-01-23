    public class FluentValidationObjectValidator : IObjectValidator
    {
        private readonly IDependencyResolver dependencyResolver;
        public FluentValidationObjectValidator(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }
        public void Validate<T>(T instance, params string[] ruleSet)
        {
            var validator = this.dependencyResolver
                .Resolve<IValidator<T>>();
            var result = ruleSet.Length == 0
                ? validator.Validate(instance)
                : validator.Validate(instance, ruleSet: ruleSet.Join());
            if(!result.IsValid)
                throw new ValidationException(MapValidationFailures(result.Errors));
        }
        public async Task ValidateAsync<T>(T instance, params string[] ruleSet)
        {
            var validator = this.dependencyResolver
               .Resolve<IValidator<T>>();
            var result = ruleSet.Length == 0
                ? await validator.ValidateAsync(instance)
                : await validator.ValidateAsync(instance, ruleSet: ruleSet.Join());
            if(!result.IsValid)
                throw new ValidationException(MapValidationFailures(result.Errors));
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
