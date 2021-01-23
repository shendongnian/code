    using System;
    using System.Security.Cryptography.X509Certificates;
    
    namespace InstallCertificate
    {
        class Program
        {
            static void Main(string[] args)
            {
                string cerFileName = args[0];
                X509Certificate2 certificate = new X509Certificate2(cerFileName);
                X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
                store.Close();
            }
        }
    }
