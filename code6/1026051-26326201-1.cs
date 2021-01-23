    public IdentityContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new IdentityDropCreateInitializer());
        }
