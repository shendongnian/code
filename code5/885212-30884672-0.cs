      List<ValidationResult> validationResults = new List<ValidationResult>();
                List<ValidationAttribute> validationAttributes = new List<ValidationAttribute>();
                validationAttributes.Add(new CustomValidationAttribute(typeof(ClaimValidator), "ValidateClaim"));
    
                bool result = Validator.TryValidateValue(claimObject,
                                     new ValidationContext(claimObject, null, null),
                                     validationResults,
                                     validationAttributes);
