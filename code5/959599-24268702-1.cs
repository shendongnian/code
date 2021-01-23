    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    public bool HasValidCertificate(url){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        response.Close();
        X509Certificate cert = request.ServicePoint.Certificate;
        X509Certificate2 cert2 = new X509Certificate2(cert);
        string cn = cert2.GetIssuerName();
        string cedate = cert2.GetExpirationDateString();
        string cpub = cert2.GetPublicKeyString();
        return !string.IsNullOrEmpty(cn) && cedate > DateTime.Now && !string.IsNullOrEmpty(cpub);
    }
