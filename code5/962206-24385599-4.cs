    private IUserRepository _userRepository;
    private ICustomerRepository _customerRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? new UserRepository();
        _customerRepository = _customerRepository ?? new CustomerRepository();
    }
