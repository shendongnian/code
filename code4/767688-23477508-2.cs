    using Flurl;
    using Flurl.Http;
    ...
    try {
        var response = this.baseUrl
            .AppendPathSegment(relativeUri)
            .WithBasicAuth(username, password)
            .WithHeader("Accept", "application/json")
            .GetAsync().Result;
        return true;
    }
    catch (FlurlHttpException ex) {
        // Flurl throws on unsuccessful responses. Null-check ex.Response,
        // then do your switch on ex.Response.StatusCode.
    }
