    using System.Net;
    using ConsoleApplication.soapHeaderServices;
    
    namespace ConsoleApplication
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var ipAddressHeader = new IpAddressHeader();
                ipAddressHeader.IpAddress = GetIpAddress();
    
                var serviceClient = new SoapHeaderService();
                serviceClient.IpAddressHeaderValue = ipAddressHeader;
    
                serviceClient.LogIpAddress();
            }
    
            static string GetIpAddress()
            {
                var ipAddress = "?";
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var address in host.AddressList)
                {
                    if (address.AddressFamily.ToString() != "InterNetwork")
                    {
                        continue;
                    }
    
                    ipAddress = address.ToString();
                    break;
                }
    
                return ipAddress;
            }
        }
    }
