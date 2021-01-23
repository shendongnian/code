    public void DoOperation(List<string> strings)
    { 
        var validator = new InlineValidator<List<string>>();
        validator.RuleFor(l => l).Must(l => l.Any()).WithMessage("No one");
        validator.ValidateAndThrow(strings)     
    }
