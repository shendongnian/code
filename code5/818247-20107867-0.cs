    protected override void Seed(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    // new ApplicationDbContext() // <- no
                    context // yes!
                    ));
