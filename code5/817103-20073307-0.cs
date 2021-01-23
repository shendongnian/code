    HtmlHelper.GenerateRouteLink(Request.RequestContext,
                                 RouteTable.Routes,
                                 "Click here.",
                                 targetRouteName,
                                 Request.Url.Scheme,
                                 Request.Url.Authority,
                                 "",
                                 new RouteValueDictionary(new { action = "ResetPasswordAction", controller = "YourController", passwordToken = token }),
                                 new Dictionary<string, object>()
        );
