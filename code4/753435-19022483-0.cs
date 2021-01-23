    public static bool canAccess(DirectoryInfo dirInfo)
    {
        Uri uri = new Uri(dirInfo.FullName);
    
        // is this a remote path?
        if (uri.IsUnc)
        {
            if (hostOnline(uri.Host))
            {
                // check if remote path exists
                if (!dirInfo.Exists)
                {
                    string domain = dirInfo.FullName;
                    ErrorClass res = PinvokeWindowsNetworking.connectToRemote(domain, null, null, true);
                    if (res == null)
                    {
                        if (!dirInfo.Exists)
                            throw new Exception(
                                string.Format("No access permissions or directory not existing."));
                        return true;
                    }
                    else if (res.num == 53)
                        throw new Exception("Remote directory not existing.");
                    else
                        throw new Exception(
                            string.Format("(Code {0}): {1}", res.num, res.message));
                }
            }
            else
                throw new Exception("Unknown host or not online.");
        }
    
        // local directory existing?
        return dirInfo.Exists;
    }
    
    private static bool hostOnline(string hostname)
    {
        Ping ping = new Ping();
        try
        {
            PingReply pr = ping.Send(hostname);
            return pr.Status == IPStatus.Success;
        }
        catch (Exception)
        {
            return false;
        }
    }
