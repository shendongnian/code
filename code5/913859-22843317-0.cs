    static bool IsValidatorType(Type t)
    {
        while(t != null)
        {
            if(t.IsGenericType && t.GetGenericTypeDefinition == typeof(AbstractValidator<>))
            {
                return true;
            }
            t = t.BaseClass;
        }
        return false;
    }
    var validatorTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(IsValidatorType);
