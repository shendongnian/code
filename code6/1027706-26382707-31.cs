    using System;
    using System.Security.Claims;
    using System.Security.Principal;
    namespace YourNameSpace {
        public static class IdentityExtensions {
            public static string GetFullName(this IIdentity identity) {
                if (identity == null)
                    throw new ArgumentNullException("identity");
                var claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity == null)
                    return null;
                var surname = Microsoft.AspNet.Identity.IdentityExtensions.FindFirstValue(claimsIdentity, "Surname");
                var familyName = Microsoft.AspNet.Identity.IdentityExtensions.FindFirstValue(claimsIdentity, "FamilyName");
                return surname + " " + familyName;
            }
        }
    }
