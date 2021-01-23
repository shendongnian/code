    public static string getTerms()
    {
        string key = GetKeyFromDb(CONSTANTS.TERMS);
        if (!string.IsNullOrEmpty(key))
        {
             return TextResources.ResourceManager.GetString(key);
