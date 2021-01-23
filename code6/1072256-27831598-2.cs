    services.AddIdentity<ApplicationUser, IdentityRole>(Configuration,
        // configure identity options
            o => {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonLetterOrDigit = false;
                o.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();
