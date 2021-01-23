    public static String[] GetFiles(String path, String searchPattern)
    {
        if (path == null)
            throw new ArgumentNullException("path");
        if (searchPattern == null)
            throw new ArgumentNullException("searchPattern");
        Contract.Ensures(Contract.Result<String[]>() != null);
        Contract.EndContractBlock();
 
        return InternalGetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
    }
