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
            rd.Values["controller"] = "Category";
            rd.Values["action"] = "Index";
            rd.Values["categories"] = categories.Split('/');
            return rd;
        }
    }
