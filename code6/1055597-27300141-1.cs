    protected ILookupMapper LookupMapper { get; set; }
    protected IEmailService EmailService { get; set; }
    
    public AdministrationService(ILookupMapper lookupMapper, IEmailService emailService)
    {
    	LookupMapper = lookupMapper;
    	EmailService = emailService;
    }
