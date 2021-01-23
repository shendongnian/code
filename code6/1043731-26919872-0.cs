    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Web.Mvc;   
    namespace Atlas.Core.Attributes
    {
        /// <summary>
        /// Add the following decoration: [ConditionalRequired("Model", "Field")]
        /// Model = client model being used to bind object
        /// Field = the field that if not null makes this field required.
        /// </summary>
        public class ConditionalRequiredAttribute : ValidationAttribute, IClientValidatable
        {
            private const string DefaultErrorMessageFormatString = "The {0} field is required.";
            private readonly string _dependentPropertyPrefix;
            private readonly string _dependentPropertyName;
    
            public ConditionalRequiredAttribute(string dependentPropertyPrefix, string dependentPropertyName)
            {
                _dependentPropertyPrefix = dependentPropertyPrefix;
                _dependentPropertyName = dependentPropertyName;
                ErrorMessage = DefaultErrorMessageFormatString;
            }
    
            protected override ValidationResult IsValid(object item, ValidationContext validationContext)
            {
                PropertyInfo property = validationContext.ObjectInstance.GetType().GetProperty(_dependentPropertyName);
                object dependentPropertyValue = property.GetValue(validationContext.ObjectInstance, null);
    
                if (dependentPropertyValue != null && item == null)
                    return new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName));
    
                return ValidationResult.Success;
            }
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                var rule = new ModelClientValidationRule
                {
                    ErrorMessage = string.Format("{0} is required", metadata.GetDisplayName()),
                    ValidationType = "conditionalrequired",
                };
    
                rule.ValidationParameters.Add("requiredpropertyprefix", _dependentPropertyPrefix);
                rule.ValidationParameters.Add("requiredproperty", _dependentPropertyName);
                yield return rule;
            }
        }
    }
  
