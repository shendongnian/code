     /// <summary>
        /// This validation attribute is an extension to RequiredAttribute that can be used to choose either of the two 
        /// validation messages depending on a property in the context of same model.
        /// </summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
        public class RequiredExtensionAttribute : RequiredAttribute
        {
            private string _errorMessageIfTruthy;
            private string _errorMessageIfFalsy; 
            private string _dependentProperty;
    
            public RequiredExtensionAttribute(string dependentproperty, string errorMessageIfTruthy, string errorMessageIfFalsy)
            {
                _errorMessageIfTruthy = errorMessageIfTruthy;
                _dependentProperty = dependentproperty;
                _errorMessageIfFalsy = errorMessageIfFalsy;
    
            }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var propertyTestedInfo = validationContext.ObjectType.GetProperty(this._dependentProperty);
                if (propertyTestedInfo == null)
                {
                    return new ValidationResult(string.Format("unknown property {0}", this._dependentProperty));
                }
    
                var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
    
                if (IsValid(value))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult((bool)propertyTestedValue ? _errorMessageIfTruthy : _errorMessageIfFalsy);
                }
            }
        }
