    public bool IsAuthenticated(string server, string username, string password)
    {
        bool authenticated = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry(server, username, password);
            object nativeObject = entry.NativeObject;
            authenticated = true;
        }
        catch (DirectoryServicesCOMException cex)
        {
            //not authenticated; reason why is in cex
        }
        catch (Exception ex)
        {
            //not authenticated due to some other exception [this is optional]
        }
        return authenticated;
    }
