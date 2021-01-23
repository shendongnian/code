    public override Task<TUser> FindByEmailAsync(string email) {
    return this.GetUserAggregateAsync(u => u.Email.ToUpper() == email.ToUpper() 
        && u.TenantId == this.TenantId);
    
    }
