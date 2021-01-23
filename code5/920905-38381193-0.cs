    // Set to no-cache if the version requested does not match
    bool noCache = false;
    var request = context.HttpContext.Request;
    if (request != null) {
        string queryVersion = request.QueryString.Get(VersionQueryString);
            if (queryVersion != null && bundleResponse.GetContentHashCode() != queryVersion) {
                    noCache = true;
        }
    }
