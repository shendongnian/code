    public class CustomRouteConstraint : IRouteConstraint
    {
        #region IRouteConstraint Members
        private TemplateType m_type;
        public CustomRouteConstraint(TemplateType type)
            :base()
        {
            m_type = type;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool returnValue = false;
            SitemapNode sitemapNode = GetSiteMapNode(httpContext.Request);
            if (sitemapNode != null && sitemapNode.TemplateType == m_type)
            {
                return true;
            }
            return returnValue;
        }
        #endregion
        private static SitemapNode GetSiteMapNode(HttpRequestBase request)
        {
            //get the aboslute url
            string url = request.Url.AbsolutePath;
            return SitemapManager.GetSiteMapNode(url);
        }
    }
