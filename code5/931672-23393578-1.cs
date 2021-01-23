    void func(...)
    {
        try
        {
             ...
             func(...);
        }
        catch (Exception ex)
        {
            ex.Property = value;
            throw; // Note: no variable name here, will throw last exception and preserve stack trace
        }
    }
