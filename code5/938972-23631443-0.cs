    public class DnsWrapper : IDnsWrapper
    {
        public IPHostEntry GetHostEntry(string hostNameOrAddress)
        {
             Dns.GetHostEntry(hostNameOrAddress);
        }
    }
