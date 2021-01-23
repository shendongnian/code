    public IEnumerable<string> Validate(ClassToValidate obj)
    {
      return (String.IsNullOrEmpty(obj.Name) ? new [] { "empty name" } : Enumerable.Empty<string>())
          .Concat(ValidateSubObject(obj.OtherObjectToValidate));
    }
