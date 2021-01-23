    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.DirectoryServices;
    /// This is sample code only so please enjoy it with all care
    /// and no responsibility :) 
    /// 
    namespace FindUserWithCert
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] certRaw; 
                X509Certificate2 x509Cert = new X509Certificate2(args[0]); 
                certRaw = x509Cert.GetRawCertData();
    
                string certBytes = "";
    
                foreach (byte b in certRaw){
                    certBytes += String.Format("\\{0:X}", b);
                    //Console.Write (String.Format("\\{0:X}",b));
                }
    
                DirectorySearcher findUser = new DirectorySearcher("(&(objectClass=user)(userCertificate=" + certBytes + "))");
    
                foreach (System.DirectoryServices.SearchResult thing in findUser.FindAll())
                {
                    Console.WriteLine(thing.Path.ToString());
                }
            
            }
        }
    }
