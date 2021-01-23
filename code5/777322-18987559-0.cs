    var queryString = actionContext.Request.RequestUri.Query;
    if(!String.IsNullOrWhiteSpace(queryString))
    {
        string token = HttpUtility.ParseQueryString(
                             queryString.Substring(1))["auth_token"];
    }
