    // a dictionary that holds which bill text keyword maps to which provider
    static Dictionary<string, string> BillTextToProvider = new Dictionary<string, string> {
        {"SWGAS.COM", "Southwest Gas"},
        {"georgiapower.com", "Georgia Power"}
        // ...
    };
    
    // a regex that will match any of the keys of this dictionary
    // i.e. any of the bill text keywords
    static Regex BillTextRegex = new Regex(
        string.Join("|", // to alternate between the "words
        BillTextToProvider
            .Keys // grab the keywords
            .Select(bt=>Regex.Escape(bt)))); // escape any special characters in them
    
    /// If any of the bill text keywords is found, return the corresponding provider.
    /// Otherwise, return null.
    string GetProvider(string billText) 
    {
        var match = BillTextRegex.Match(billText);
        if (match.Success) 
            // the Value of the match will be the found substring
            return BillTextToProvider[match.Value];
        else return null;
    }
    
    // Your original code now reduces to:
    var provider = GetProvider(txtvar.BillText);
    // the if is be unnecessary if txtvar.Provider should be null in case it can't be 
    // determined
    if (provider != null) 
        txtvar.Provider = provider;
