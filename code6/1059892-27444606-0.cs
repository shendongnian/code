        private static X509Certificate2 FindSubjectNameInStore(string subjectName,
                                                              StoreName name, StoreLocation location)
        {
            //creates the store based on the input name and location e.g. name=My
            var certStore = new X509Store(name, location);
            certStore.Open(OpenFlags.ReadOnly);
            //finds the certificate in question in this store
            var certCollection = certStore.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, subjectName, false);
            certStore.Close();
            return certCollection.Count > 0 ? certCollection[0] : null;
        }
