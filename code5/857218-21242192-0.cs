    private IHttpHandler GetHandlerForPathParts(String[] pathParts)
    {
        var pathController = string.Intern(pathParts[0].ToLower());
        if (pathParts.Length == 1)
        {
            if (pathController == "metadata")
                return new IndexMetadataHandler();
            return null;
        }
        ...
    }
