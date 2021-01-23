    public Uri BuildUri() 
    {
        var viewType = ViewLocator.LocateTypeForModelType(typeof(TViewModel), null, null);
             
        if(viewType == null) 
        {
            throw new InvalidOperationException(string.Format("No view was found for {0}. See the log for searched views.", typeof(TViewModel).FullName));
        }
    
        var packUri = ViewLocator.DeterminePackUriFromType(typeof(TViewModel), viewType);
        var qs = BuildQueryString();
    
        return new Uri(packUri + qs, UriKind.Relative);
    }
