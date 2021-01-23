    public void Method(string name, DateTime? date)
    {  
         Contract.Requires(!string.isNullOrEmpty(name), "'name' cannot be null");
         Contract.Requires(date.HasValue, "'date' is required");
    }
