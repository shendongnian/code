    private int _timesMyCustomerWasAccessed;
    private Customer _myCustomer;
    public Customer MyCustomer
    {
      get
      {
        _timesMyCustomerWasAccessed++;
        return _myCustomer;
      }
    }
