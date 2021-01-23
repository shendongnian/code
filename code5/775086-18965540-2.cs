    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Web.Mvc;
    namespace WebApplication.Common
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        public class RuntimeRequiredValidationAttribute : ValidationAttribute, IClientValidatable
        {
            public string BooleanSwitch { get; private set; }
            public RuntimeRequiredValidationAttribute(string booleanSwitch = "IsRequired") : base("The {0} field is required.")
            {
                BooleanSwitch = booleanSwitch;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                PropertyInfo property = validationContext.ObjectType.GetProperty(BooleanSwitch);
                if (property == null)
                {
                    return null;
                }
                if ((bool) property.GetValue(validationContext.ObjectInstance, null) &&
                     (value == null || String.IsNullOrWhiteSpace((string)value)))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                    return null;
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
