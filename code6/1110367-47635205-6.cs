    public override Task CreateAsync(TUser user) {
    if (user == null) {
        throw new ArgumentNullException("user");
    }
    
    user.TenantId = this.TenantId;
    return base.CreateAsync(user);
    
    }
