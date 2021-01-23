    public static String[] GetFiles(String path)
    {
        if (path == null)
            throw new ArgumentNullException("path");
        Contract.Ensures(Contract.Result<String[]>() != null);
        Contract.EndContractBlock();
 
        return InternalGetFiles(path, "*", SearchOption.TopDirectoryOnly);
    }
