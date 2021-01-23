    public class CompareWithDisplayNameAttribute : CompareAttribute, IClientValidatable
    {
        public CompareWithDisplayNameAttribute(string otherProperty)
            : base(otherProperty)
        {
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            // Custom validation goes here.
            yield return new ModelClientValidationRule();
        }
    }
