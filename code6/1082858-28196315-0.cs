    static class ValidatorExtension
    {
        public static IList<ValidationResult> ValidateMany<T>(this IValidator validator, IList objectsToValidate)
        {
            var results = new List<ValidationResult>();
            foreach (var obj in objectsToValidate)
            {
                var validationResult = validator.Validate((T)obj);
                results.Add(validationResult);
            }
            return results;
        }
    }
