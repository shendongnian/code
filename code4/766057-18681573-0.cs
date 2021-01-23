    public static class RedirectToRouteExtensions
        {
            public static RedirectToRouteResult WithQuery(this RedirectToRouteResult redirectResult, string name, string val)
            {
                redirectResult.RouteValues.Add(name, val);
                return redirectResult;
            }
            public static RedirectToRouteResult And(this RedirectToRouteResult redirectResult, string name, string val)
            {
                return redirectResult.WithQuery(name, val);
            }
    }
