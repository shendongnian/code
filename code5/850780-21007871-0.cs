        public static class UserUtils
        {
            public static object GetUserId()
            {
                return Membership
                    .GetUser(HttpContext.Current.User.Identity.Name)
                    .ProviderUserKey;           
            }
        }
