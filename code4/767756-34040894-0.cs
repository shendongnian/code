    public class GroupRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string[] _serverSideProperties;
        public GroupRequiredAttribute(params string[] serverSideProperties)
        {
            _serverSideProperties = serverSideProperties;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_serverSideProperties == null || _serverSideProperties.Length < 1)
            {
                return null;
            }
            foreach (var input in _serverSideProperties)
            {
                var propertyInfo = validationContext.ObjectType.GetProperty(input);
                if (propertyInfo == null)
                {
                    return new ValidationResult(string.Format("unknown property {0}", input));
                }
                var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (propertyValue is string && !string.IsNullOrEmpty(propertyValue as string))
                {
                    return null;
                }
                if (propertyValue != null)
                {
                    return null;
                }
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "grouprequired"
            };
            rule.ValidationParameters["grouprequiredinputs"] = string.Join(",", this._serverSideProperties);
            yield return rule;
        }
    }
