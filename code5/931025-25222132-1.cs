        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager , string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this , authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
