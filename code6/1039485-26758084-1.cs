    public ValidationResult Validate(CustomerType customerType)
    {
        CustomerTypeValidator validator = new CustomerTypeValidator();
        validator.RuleFor(x => x).Must(HaveUniqueNumber);
        return validator.Validate(customerType);
    }
    public bool HaveUniqueNumber(CustomerType customerType)
    {
        var result = repository.Get(x => x.Number == customerType.Number)
            .Where(x => x.Id != customerType.Id)
            .FirstOrDefault();
            
        return result == null;
        //return true;
    }
