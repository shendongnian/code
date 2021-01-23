    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var addressModel = value as AddressModel;
        if (addressModel != null)
        {
            // Do some stuff against addressModel here to determine if valid...
            return base.IsValid(value, context);
        }
        return ValidationResult.Success;
    }
