    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
            
        var conditionalPropertyInfo = validationContext.ObjectType.GetProperty(this.MinLengthPropName);
        var conditionalPropertyValue = conditionalPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        this.ErrorMessage = string.Format(this.ErrorMessage, conditionalPropertyValue.ToString())
        // YOUR OTHER CODE HERE
    }
