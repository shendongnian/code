    namespace MyProject.MyNamespace.MyExtensions
    {
        public static class IdentityExtensions
        {
            public static bool IsInIdentityRole(this IPrincipal user, string role)
            {
                var userManager = GetUserManager(); //implement this!
                return userManager.IsInRole(user.Identity.GetUserId(), role); 
            }
        }
    }
