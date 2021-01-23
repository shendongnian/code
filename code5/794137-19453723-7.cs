    using System;
    using System.IO;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using SoapHeaders;
    
    namespace WebService
    {
     
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
    
        public class SoapHeaderService : System.Web.Services.WebService
        {
            public IpAddressHeader IpAddressHeader;
    
            [WebMethod]
            [SoapDocumentMethod(OneWay = true)]
            [SoapHeader("IpAddressHeader")]
            public void LogIpAddress()
            {
                var logFile = string.Format(@"C:\Logs\{0:yyyy-MM-dd HH.mm.ss.ffff}.log", DateTime.Now);
    
                string ipAddress;
    
                if (IpAddressHeader == null || string.IsNullOrEmpty(IpAddressHeader.IpAddress))
                {
                    ipAddress = "?";
                }
                else
                {
                    ipAddress = IpAddressHeader.IpAddress;
                }
    
                File.WriteAllText(logFile, string.Format("Client Address --> {0}", ipAddress));
            }
        }
    }
