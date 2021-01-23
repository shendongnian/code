    public static XNamespace ns =  @"http://schemas.microsoft.com/developer/msbuild/2003";
    public static XName MsElementName(string baseName)
    {
        return ns + baseName;   
    }
