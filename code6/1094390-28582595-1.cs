    public Customer CurrentCustomer { get; set; }
    public RelayCommand<Customer> CustomerListBoxSelectionChanged { get; set; }
    
    private void OnCustomerListBoxSelectionChanged(Customer customer)
    {
        CurrentCustomer = customer;
        NewCustomerName = customer.CustomerName;
    }
    private string _newCustomerName;
    public string NewCustomerName
    {
        get { return _newCustomerName; }
        set
        {
            if (_newCustomerName == value)
                return;
    
             _newCustomerName = value;
             RaisePropertyChanged("NewCustomerName");
        }
    }
