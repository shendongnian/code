    var validationResults = new List<ValidationResult>();
    var validationAttributes = new List<ValidationAttribute>();
    validationAttributes.Add(new CustomValidationAttribute(typeof(ClaimValidator), "ValidateClaim"));
    var result = Validator.TryValidateValue(claimObject,
                                            new ValidationContext(claimObject, null, null),
                                            validationResults,
                                            validationAttributes);
