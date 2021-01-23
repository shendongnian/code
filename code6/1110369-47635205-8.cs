    public override Task<TUser> FindByNameAsync(string userName) {
    return this.GetUserAggregateAsync(u => u.UserName.ToUpper() == userName.ToUpper() 
        && u.TenantId == this.TenantId);
    
    }
