    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using System.Collections.Specialized;
    
    namespace ConfigTest
    {
        class Program
        {
            public static string machinename;
            public static string hostname;
            public static NameValueCollection _AppSettings;
    
            static void Main(string[] args)
            {
                machinename = System.Net.Dns.GetHostName().ToLower();
                hostname = "abc.com";// System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToLower().Replace(machinename + ".", "");
                _AppSettings = ConfigurationManager.GetSection("domain/" + hostname) as System.Collections.Specialized.NameValueCollection;
            }
        }
    }
