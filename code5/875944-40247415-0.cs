     public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException("filters");
            }
            filters.Add(new HandleErrorAttribute());
            var authorizeAttribute = new AuthorizeAttribute
            {
                Roles = "Domain\Group" // Role = group in Active Directory
            };
            filters.Add(authorizeAttribute);
        }
    }
