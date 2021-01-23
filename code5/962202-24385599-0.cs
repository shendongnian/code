    private ICustomerService _customerService;
    public UserModel()
        : this(new CustomerService())
    {
    }
    public UserModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public int ID { get; set; }
    ....
    public IEnumerable<CustomerModel> CustomerList { get; set; }
    
