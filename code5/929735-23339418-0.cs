    private readonly EFDbContext context;
    private readonly ISaleActionRepository saleActionRepository;
    private readonly IUserRepository userRepository;
    private readonly CommonMethods commonMethods;
    public TestController(ISaleActionRepository saleActionRepository, 
        IUserRepository userRepository, EFDbContext context, CommonMethods commonMethods)
    {
        this.saleActionRepository = saleActionRepository;
        this.userRepository = userRepository;
        this.context = context;
        this.commonMethods = commonMethods;
    }
