    var customer = new CustomerClass();
    var context = new ValidationContext(customer, serviceProvider: null, items: null);
    var results = new List<ValidationResult>();
    
    var isValid = Validator.TryValidateObject(customer, context, results);
    
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    }
