    public override bool IsValid(object value)
    {
      var objectToValidate = value as MyValidatableClass;
    
      // some code for validation.
      if (objectToValidate.SomeProperty != "correct")
        return false;
    }
