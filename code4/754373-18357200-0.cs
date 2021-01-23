     private static void CompareCertSerialse()
        {
            string oauthCertificateFindValue = "7C00001851CBFF5E9F563E236F000000001851";
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 cert in store.Certificates)
            {
                Console.WriteLine(cert.SerialNumber + "=" + oauthCertificateFindValue);
                if (cert.SerialNumber == oauthCertificateFindValue)
                {
                  Console.WriteLine("FOUND FOUND FOUND>");
                  
                 //Close the store  
                  store.Close();
                  GetCert(oauthCertificateFindValue);                     
                }
            }
        }
     private static X509Certificate2 GetCert(string oauthCertificateFindValue)
        {
            //Reopen the store
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            
            X509Certificate2Collection certificateCollection = store.Certificates.Find(X509FindType.FindBySerialNumber, oauthCertificateFindValue, false);
           
            if (certificateCollection.Count == 0)
            {
                Console.WriteLine("Nothing Found");
            }
            return certificateCollection[0];
        }
