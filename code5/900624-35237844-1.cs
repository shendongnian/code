    services.AddIdentity<ChirpUser, IdentityRole>(config =>
    {
        config.User.AllowedUserNameCharacters = Properties.Resource.AllowedUsernameCharacters;
    })
    .AddEntityFrameworkStores<ChirpContext>();
