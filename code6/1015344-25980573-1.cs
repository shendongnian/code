    string provider = item["Provider"].ToString().Replace("#", "\n").TrimStart(';');
    string[] providerListing = provider.Split(new[]{";"}, StringSplitOptions.RemoveEmptyEntries));
    if(providerListing.Count > 3)
    {
        //Make an array of the first 3 providers
        string[] firstProviders = Array.Copy(providerListing, firstProviders, 3);
        //Reconcatenate with ; and add ellipsis
        provider = String.Join(";",firstProviders)+"...";
    }
        
