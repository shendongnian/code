    public class CategoriesRoute: Route
    {
        public CategoriesRoute()
            : base("{*categories}", new MvcRouteHandler())
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var rd = base.GetRouteData(httpContext);
            if (rd == null)
            {
                return null;
            }
            string categories = rd.Values["categories"] as string;
            if (string.IsNullOrEmpty(categories) || !categories.StartsWith("some-", StringComparison.InvariantCultureIgnoreCase))
            {
                // The url doesn't start with some- as per our requirement =>
                // we have no match for this route
                return null;
            }
            string[] parts = categories.Split('/');
            // for each of the parts go hit your categoryService to determine whether
            // this is a category slug or something else and return accordingly
           if (!AreValidCategories(parts)) 
           {
               // The AreValidCategories custom method indicated that the route contained
               // some parts which are not categories => we have no match for this route
               return null;
           }
            // At this stage we know that all the parts of the url are valid categories =>
            // we have a match for this route and we can pass the categories to the action
            rd.Values["controller"] = "Category";
            rd.Values["action"] = "Index";
            rd.Values["categories"] = parts;
            return rd;
        }
    }
