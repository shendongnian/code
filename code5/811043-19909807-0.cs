    private ADConnectResults Connect(string server, int port)
    try
    {
        PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, (server + ":" + port), loginUsername, loginPassword);
        return new ADConnectResults(true, principalContext);
    }
    catch(DirectoryServicesCOMException dex)
    {
         Log(dex);
         return new ADConnectResults(false);
    }
    }
