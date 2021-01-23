    public ValidationResult Validate(CustomerType customerType)
    {
        CustomerTypeValidator validator = new CustomerTypeValidator();
        validator.RuleFor(x => x.Number).Must(BeUniqueNumber);
        return validator.Validate(customerType);
    }
    public bool BeUniqueNumber(CustomerType customerType, int number)
    {
        var result = repository.Get(x => x.Number == number)
            .Where(x => x.Id != customerType.Id)
            .FirstOrDefault();
            
        return result == null;
        //return true;
    }
