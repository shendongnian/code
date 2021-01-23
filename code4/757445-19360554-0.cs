    public AccountController()
    {
        IdentityManager = new AuthenticationIdentityManager(
        new IdentityStore(new ApplicationDbContext()));
    }
