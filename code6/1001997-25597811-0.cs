    public static class GenericPrincipalExtensions
        {
        public static string FullName (this IPrincipal user)
            {
            if (user.Identity.IsAuthenticated)
                {
    
                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                    {
                    foreach (var claim in claimsIdentity.Claims)
                        {
                        if (claim.Type == "FullName")
                            return claim.Value;
                        }
                    }
                return "";
                }
            else
                return "";
            }
        }
