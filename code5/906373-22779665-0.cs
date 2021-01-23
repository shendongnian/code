    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var certBytes = File.ReadAllBytes(@"c:\cert.p12");
                var p12Pwd = "somepassword";
    
                for (var i = 0; i < 1000; i++)
                {
                    var cert = new X509Certificate2(certBytes, p12Pwd, X509KeyStorageFlags.MachineKeySet);
    
                    // this line helped keep filesize from growing   
                    // cert.Reset(); 
                }
            }
        }
    }
