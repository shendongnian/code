    public static bool TryValidateObject(object instance, ValidationContext validationContext, 
      ICollection<ValidationResult> validationResults, bool validateAllProperties)
    {
      if (instance == null)
        throw new ArgumentNullException("instance");
      if (validationContext != null && instance != validationContext.ObjectInstance)
        throw new ArgumentException(DataAnnotationsResources.
        Validator_InstanceMustMatchValidationContextInstance, "instance");
      bool flag = true;
      bool breakOnFirstError = validationResults == null;
      foreach (Validator.ValidationError validationError in 
        Validator.GetObjectValidationErrors(instance, validationContext, 
        validateAllProperties, breakOnFirstError))
      {
        flag = false;
        if (validationResults != null)
          validationResults.Add(validationError.ValidationResult);
      }
      return flag;
    }
