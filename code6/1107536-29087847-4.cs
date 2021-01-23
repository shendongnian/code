        public static class IdentityExtensions
    {
        public static bool IsExternalUser(this IIdentity identity)
        {
            ClaimsIdentity ci = identity as ClaimsIdentity;
        
            if (ci != null && ci.IsAuthenticated == true)
            {
                var value = ci.FindFirstValue(ClaimTypes.Sid);
                if (value != null && value == "Office365")
                {
                    return true;
                }
            }
            return false;
        }
    }
