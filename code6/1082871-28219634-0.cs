       public Task<bool> CheckAccessAsync(ClaimsPrincipal user, string action, params string[] resources)
        {
            var ctx = new ResourceAuthorizationContext(user ?? Principal.Anonymous, action, resources);
            return CheckAccessAsync(ctx);
        }
        public Task<bool> CheckAccessAsync(ClaimsPrincipal user, IEnumerable<Claim> actions, IEnumerable<Claim> resources)
        {
            var authorizationContext = new ResourceAuthorizationContext(
                user ?? Principal.Anonymous,
                actions,
                resources);
            return CheckAccessAsync(authorizationContext);
        }    
