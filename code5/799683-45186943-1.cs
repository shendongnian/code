        private static void dedupQuery( HttpActionContext actionContext)
        {
            var routeData = actionContext.Request.GetRouteData().Values;
            var queryString = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            if( queryString.Keys.Any(s => routeData.Keys.Contains(s)))
            {
                throw new HttpException((int)HttpStatusCode.Conflict, "DUPLICATED PARAM");
            }
        }
