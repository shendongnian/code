    private static IEnumerable<Validator.ValidationError> GetObjectValidationErrors(
      object instance, ValidationContext validationContext, 
      bool validateAllProperties, bool breakOnFirstError)
    {
      if (instance == null)
        throw new ArgumentNullException("instance");
      if (validationContext == null)
        throw new ArgumentNullException("validationContext");
      List<Validator.ValidationError> list = new List<Validator.ValidationError>();
      //Check for property errors here
      list.AddRange(Validator.GetObjectPropertyValidationErrors(instance, validationContext,
        validateAllProperties, breakOnFirstError));
      // Short circuits here if any found
      if (Enumerable.Any<Validator.ValidationError>(
        (IEnumerable<Validator.ValidationError>) list))
        return (IEnumerable<Validator.ValidationError>) list;
      // Class level validation occurs below this point
      IEnumerable<ValidationAttribute> validationAttributes = 
        Validator._store.GetTypeValidationAttributes(validationContext);
      list.AddRange(Validator.GetValidationErrors(instance, validationContext, 
        validationAttributes, breakOnFirstError));
      if (Enumerable.Any<Validator.ValidationError>(
        (IEnumerable<Validator.ValidationError>) list))
        return (IEnumerable<Validator.ValidationError>) list;
      IValidatableObject validatableObject = instance as IValidatableObject;
      if (validatableObject != null)
      {
        foreach (ValidationResult validationResult in 
          Enumerable.Where<ValidationResult>(validatableObject.Validate(validationContext), 
          (Func<ValidationResult, bool>) (r => r != ValidationResult.Success)))
          list.Add(new Validator.ValidationError((ValidationAttribute) null, instance, 
            validationResult));
      }
      return (IEnumerable<Validator.ValidationError>) list;
    }
