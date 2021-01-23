    protected virtual object GetPropertyValue(ValidationContext validationContext, string propertyName)
    {
       var properties = validationContext.ObjectInstance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
       var property = properties.FirstOrDefault(x => x.Name == propertyName);
       if (property == null)
          return null;
    
       var propertyValue = property.GetValue(validationContext.ObjectInstance, null);
       return propertyValue;
    }
    var propertyValue = GetPropertyValue(validationContext, "FlagsThatAffectValidationOnSomeProperties");
