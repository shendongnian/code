    public class MyStringLengthAdapter : DataAnnotationsModelValidator<MyStringLengthAttribute>
    {
        public MyStringLengthAdapter(ModelMetadata metadata, ControllerContext context, MyStringLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationStringLengthRule(ErrorMessage, Attribute.MinimumLength, Attribute.MaximumLength) };
        }
    }
