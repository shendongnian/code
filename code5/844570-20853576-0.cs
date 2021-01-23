        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;
            if (requestContext.RouteData.IsAreaMatch(this.area))
            {
                var tenant = this.appContext.CurrentTenant;
                // Get all of the pages
                var pages = this.routeUrlPageListFactory.GetRouteUrlPageList(tenant.Id);
                IRouteUrlPageInfo page = null;
                if (this.TryFindMatch(pages, values, out page))
                {
                    result = new VirtualPathData(this, page.VirtualPath);
                }
            }
            return result;
        }
        private bool TryFindMatch(IEnumerable<IRouteUrlPageInfo> pages, RouteValueDictionary values, out IRouteUrlPageInfo page)
        {
            page = null;
            Guid contentId = Guid.Empty;
            var action = Convert.ToString(values["action"]);
            var controller = Convert.ToString(values["controller"]);
            var localeId = (int?)values["localeId"];
            if (localeId == null)
            {
                return false;
            }
            if (Guid.TryParse(Convert.ToString(values["id"]), out contentId) && action == "Index")
            {
                page = pages
                    .Where(x => x.ContentId.Equals(contentId) &&
                        x.ContentType.ToString().Equals(controller, StringComparison.InvariantCultureIgnoreCase))
                    .Where(x => x.LocaleId.Equals(localeId))
                    .FirstOrDefault();
                if (page != null)
                {
                    return true;
                }
            }
            return false;
        }
