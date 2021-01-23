    // Note that dynamic as a parameter type is equivalent to object for callers.
    // The dynamic part is only relevant within the method.
    public string GetName(dynamic obj)
    {
        return GetNameImpl(obj);
    }
    // Fallback when no other overloads match
    private string GetNameImpl(object obj)
    {
        ...
    }
    private string GetNameImpl(IEnumerable obj)
    {
        // Maybe build up the name by calling GetName on each element?
    }
