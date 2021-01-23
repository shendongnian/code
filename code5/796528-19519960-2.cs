    public string Convert(string text)
    {
         Contract.Requires(text != null);
         Contract.Ensures(Contract.Result<string>() != null);
         return default(string); // returns dummy value
    }
