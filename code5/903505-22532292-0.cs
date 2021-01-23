    /// <summary>
    /// A configurable class wide attribute that is used to determine if at least one property of a class has received a value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingleValueConfigurableAttribute : ValidationAttribute, IClientValidatable
    {
        public SingleValueConfigurableAttribute(string errorKey)
        { ErrorMessage = Properties.Settings.Default[errorKey].ToString(); }
        public override bool IsValid(object value)
        {
            var typeInfo = value.GetType();
            var propertyInfo = typeInfo.GetProperties();
            return propertyInfo.Any(property => null != property.GetValue(value, null));
        }
        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = String.IsNullOrEmpty(ErrorMessage) ? FormatErrorMessage(metadata.DisplayName) : ErrorMessage,
                ValidationType = "enforcetrue"
            };
        }
    }
