    using System.Runtime.InteropServices;
    
    ...
    
    [DllImport("dnsapi.dll",EntryPoint="DnsFlushResolverCache")]
    private static extern UInt32 DnsFlushResolverCache ();
    
    ...
    
    public static void FlushResolverCache()
    {
        UInt32 result = DnsFlushResolverCache();
    }
