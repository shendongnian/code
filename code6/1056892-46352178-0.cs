    // parse url into UriBuilder //
    var uri = new UriBuilder(Request.RawUrl);
    
    // parse query part of url into a NameValueCollection //
    var query = HttpUtility.ParseQueryString(uri.Query);
    // update/create "Language" entry in the NameValueCollection //
    query["Language"] = DDLLanguages.SelectedValue;
    // put updated NameValueCollection back into uri querystring //
    uri.Query = query.ToString();
    // redirect page to updated uri //
    Response.Redirect(uri.ToString());
