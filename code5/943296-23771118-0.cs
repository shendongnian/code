    public static class ClaimsIdentityExtensions
    {
        public static string GetTenantId(this ClaimsIdentity identity)
        {
            var claim = identity.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.microsoft.com/identity/claims/identityprovider"));
            return (claim != null) ? claim.Value : "unknown";
        }
    }
