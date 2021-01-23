    public CustomUserManager(IUserStore<User> store,
            IPasswordHasher passwordHasher,
            IIdentityMessageService emailService)
            : base(store)
        {
            //Other validators
            MyCustomObjectType myCustomObject = new MyCustomObjectType();
            PasswordValidator = new StrongPasswordValidator(8, 100, myCustomObject);
            PasswordHasher = passwordHasher;
            EmailService = emailService;
        }
