    public void DoOperation(List<string> strings)
    { 
        if (!strings.Any())
        {
            var failures = new List<ValidationFailure>();
            failures.Add(new ValidationFailure("strings", "Must have at less one."));
 
            throw new ValidationException(failures);
        }
    }
