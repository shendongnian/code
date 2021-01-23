    using System.Net;
    static string GetProducts(string clientID, string apiKey, string url)
    {
        HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
        req.Credentials = new NetworkCredential(clientID, apiKey);
        req.ContentType = "application/x-www-form-urlencoded";
        System.Net.ServicePointManager.ServerCertificateValidationCallback +=
        delegate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        string result = string.Empty;
        using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
        {
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            result = reader.ReadToEnd();
        }
        return result;
    }
