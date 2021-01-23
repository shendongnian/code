    public bool IsInRole(string role)
    {
        if(this.Roles == null)
            this.Roles = DependencyResolver.Current
               .GetService<ISecurityService>()
               .GetUserPermissions(this.Identity.Name);
        return this.Roles.Any(p => p.Name == role);
    }
