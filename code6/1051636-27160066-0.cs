    private Task<Customer> _cache;
    public Task<Customer> GetCustomerAsync()
    {
      if (_cache != null)
        return _cache;
      _cache = GetFromWebServiceAsync();
      return _cache;
    }
