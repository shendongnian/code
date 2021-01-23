    public static bool PCIsOnline(string arg)
    {
    Ping pingSender = new Ping();
    PingOptions options = new PingOptions();
    options.DontFragment = true;
    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    byte[] buffer = Encoding.ASCII.GetBytes(data);
    int timeout = 2;
    try
    {
        PingReply reply = pingSender.SendAsync(arg, timeout, buffer, options);
        if (reply.Status == IPStatus.Success) { return true; }
        else { return false; }
    }
    catch
    {
        return false;
    }
    }
