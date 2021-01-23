    public static class UriHostResolveExtension
    {
    	public static String ResolveHostnameToIp(this Uri uri)
    	{
    		if (uri.HostNameType == UriHostNameType.Dns)
    		{
    			IPHostEntry hostEntry = Dns.GetHostEntry(uri.Host);
    			if (hostEntry.AddressList.Length > 0)
    				return hostEntry.AddressList[0].ToString();
    		}
    		return uri.Host;
    	}
    }
