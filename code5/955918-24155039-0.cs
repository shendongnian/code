    public bool IsCustomerSelected
    {
        ....
        set
        {
            if (value != _isCustomerSelected)
            {
                _isCustomerSelected = value;
                RaisePropertyChaged("IsCustomerSelected");
                RaisePropertyChaged("CanEditCustomer");
            }
        }
    }
