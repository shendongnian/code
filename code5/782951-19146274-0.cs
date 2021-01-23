    public Boolean IsValid(String foo)
    {
        if (!Validator.Validate(foo))
        {
            return false;
        }
    
        return true;
    }
