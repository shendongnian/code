        public async Task<X509Certificate2> GetCertificate(string certificateThumbprint)
        {
            var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var cert = store.Certificates.OfType<X509Certificate2>()
                .FirstOrDefault(x => x.Thumbprint == certificateThumbprint);
            store.Close();
            return cert;
        }
