    internal static class IIdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            var result = Guid.Empty;
            string id = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(identity);
            Guid.TryParse(id, out result);
            return result;
        }
        public static string GetUserName(this IIdentity identity)
        {
            string result = Microsoft.AspNet.Identity.IdentityExtensions.GetUserName(identity);
            return result;
        }
        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            string result = Microsoft.AspNet.Identity.IdentityExtensions.FindFirstValue(identity, claimType);
            return result;
        }
    }
