    private void browserAuthentication_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        if(e.Uri.Host.Equals( _callbackUri.Host))
        {
            e.Cancel = true;
                
            //This code is required. Otherwise the box api navigation will popup an external browser window.
            browserAuthentication.Navigate("about:blank");
            this._authenticationResponseValues = GetQueryOptions(e.Uri);
        }
    }
    private IDictionary<string, string> GetQueryStringParamAndValues(Uri resultUri)
    {
        string[] queryParams = null;
        var queryValues = new Dictionary<string, string>();
        int fragmentIndex = resultUri.AbsoluteUri.IndexOf("#", StringComparison.Ordinal);
        if (fragmentIndex > 0 && fragmentIndex < resultUri.AbsoluteUri.Length + 1)
        {
            queryParams = resultUri.AbsoluteUri.Substring(fragmentIndex + 1).Split('&');
        }
        else if (fragmentIndex < 0)
        {
            if (!string.IsNullOrEmpty(resultUri.Query))
            {
                queryParams = resultUri.Query.TrimStart('?').Split('&');
            }
        }
        if (queryParams != null)
        {
            foreach (var param in queryParams)
            {
                if (!string.IsNullOrEmpty(param))
                {
                    string[] kvp = param.Split('=');
                    queryValues.Add(kvp[0], System.Net.WebUtility.UrlDecode(kvp[1]));
                }
            }
        }
        return queryValues;
    }
