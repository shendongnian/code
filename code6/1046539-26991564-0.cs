    public static bool IsConnectedToInternet()
    {
	    string host = "www.google.com";
	    bool result = false;
	    Ping p = new Ping();
	    try
	    {
		    PingReply reply = p.Send(host, 5000);
		    if (reply.Status == IPStatus.Success)
			    return true;
	    }
	    catch { }
	    return result;
    }
