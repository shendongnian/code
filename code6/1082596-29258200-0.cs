    public bool IsNumberUnique(CustomerType customerType, int id)
    {
        var result = customerTypeRepository.SearchFor(x => x.Number == customerType.Number).Where(x => x.Id != customerType.Id).FirstOrDefault();
        return result == null;
    }
    public ValidationResult Validate(CustomerType customerType)
    {
        CustomerTypeValidator validator = new CustomerTypeValidator();
        validator.RuleFor(x => x.Id).Must(IsNumberUnique).WithState(x => CustomerTypeError.NumberNotUnique);
        return validator.Validate(customerType);
    }
