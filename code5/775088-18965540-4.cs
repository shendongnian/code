    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Web.Mvc;
    namespace WebApplication.Common
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        public class RuntimeRequiredAttribute : ValidationAttribute, IClientValidatable
        {
            public string BooleanSwitch { get; private set; }
            public bool AllowEmptyStrings { get; private set; }
            public RuntimeRequiredAttribute(string booleanSwitch = "IsRequired", bool allowEmpytStrings = false ) : base("The {0} field is required.")
            {
                BooleanSwitch = booleanSwitch;
                AllowEmptyStrings = allowEmpytStrings;
            }
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {
                    PropertyInfo property = validationContext.ObjectType.GetProperty(BooleanSwitch);
            
                    if (property == null || property.PropertyType != typeof(bool))
                    {
                        throw new ArgumentException(
                            BooleanSwitch + " is not a valid boolean property for " + validationContext.ObjectType.Name,
                            BooleanSwitch);
                    }
                    if ((bool) property.GetValue(validationContext.ObjectInstance, null) &&
                        (value == null || (!AllowEmptyStrings && value is string && String.IsNullOrWhiteSpace(value as string))))
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                    return ValidationResult.Success;
                }
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                ControllerContext context)
            {
                object model = context.Controller.ViewData.Model;
                bool required = (bool)model.GetType().GetProperty(BooleanSwitch).GetValue(model, null);
                if (required)
                {
                    yield return
                        new ModelClientValidationRequiredRule(
                            FormatErrorMessage(metadata.DisplayName ?? metadata.PropertyName));
                }
                else
                //we have to return a ModelCLientValidationRule where
                //ValidationType is not empty or else we get an exception
                //since we don't add validation rules clientside for 'notrequired'
                //no validation occurs and this works, though it's a bit of a hack
                {
                    yield return
                        new ModelClientValidationRule {ValidationType = "notrequired", ErrorMessage = ""};
                }
            }
        }
    }
