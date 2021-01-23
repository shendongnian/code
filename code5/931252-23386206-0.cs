    public ICollection<IValidatableObject> Validations { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var valid = Enumerable.Empty<ValidationResult>();
        if (Validations != null)
        {
            valid = Validations.Aggregate(valid, (current, validate) => current.Concat(validate.Validate(validationContext)));
        }
        return valid;
    }
