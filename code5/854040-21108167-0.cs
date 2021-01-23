    private List<Customer> _AllCustomers;
    public IList<Customer> AllCustomers
    {
        get
        {
            if (_AllCustomers == null)
            {
                _AllCustomers = DAL.GetAllCustomers().ToList().AsReadOnly(); 
            }
            return _AllCustomers;
        }
    }
