    using Flurl;
    using Flurl.Http; // if you need it
    var url = "http://www.myBase.com"
        .AppendPathSegment("get")
        .SetQueryParams(new { a = 1, b = "c" }) // multiple
        .SetQueryParams(dict)                   // multiple with an IDictionary
        .SetQueryParam("name", "value")          // one by one
        
        // if you need to call the URL with HttpClient...
        
        .WithOAuthBearerToken("token")
        .WithHeaders(new { a = "x", b = "y" })
        .ConfigureHttpClient(client => { /* access HttpClient directly */ })
        .PostJsonAsync(new { first_name = firstName, last_name = lastName });
