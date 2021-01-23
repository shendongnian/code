    public static class IdentityExtensions
    {
        public static int GetSalesId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.SalesId);
    
            if (claim == null)
                return 0;
    
            return int.Parse(claim.Value);
        }
    
        public static string GetName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Name);
    
            return claim?.Value ?? string.Empty;
        }
    }
