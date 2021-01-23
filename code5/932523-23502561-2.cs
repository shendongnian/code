        public class StringLengthAttributeAdapter : DataAnnotationsModelValidator<StringLengthAttribute>
        {
          public StringLengthAttributeAdapter(ModelMetadata metadata, ControllerContext context, StringLengthAttribute attribute): base(metadata, context, attribute)
          {}
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
          {
            return new[] { new ModelClientValidationStringLengthRule(ErrorMessage, **0**, Attribute.MaximumLength) };
          }
        }
