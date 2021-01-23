    services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
    {
       options.Cookies.ApplicationCookie.AutomaticChallenge = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext, int>()
    .AddDefaultTokenProviders();
