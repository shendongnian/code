    protected void Session_Start() {
    
        if (HttpContext.Current.Request.Url.OriginalString.ToLowerInvariant().EndsWith("something")) {
            return;
        }
                
        // your initialization here that should not be executed 
        // for clients accessing the site using the above url
    }
