    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
        return base.IsValid(value, validationContext);
    }
