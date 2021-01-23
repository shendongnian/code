    public string GetCustomer(int custId)
    {
        // EDIT THIS TO MATCH YOUR CLIENT CERTIFICATE: the subject key identifier in hexadecimal.
        string subjectKeyIdentifier = "39b66c2a49b2059a15adf96e6b2a3cda9f4b0e3b";
		
        X509Store store = new X509Store("My", StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, subjectKeyIdentifier, true);
        X509Certificate2 certificate = certificates[0];
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.foo.net/api/customer/v1/" + custId);
        req.ClientCertificates.Add(certificate);
        req.UserAgent = "LOL API Client";
        req.Accept = "application/json";
        req.Method = WebRequestMethods.Http.Get;
        string result = null;
        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
        {
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            result = reader.ReadToEnd();
        }
        return result;
    }
