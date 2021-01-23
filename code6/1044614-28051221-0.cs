    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateRemoteCertificate);
    
    private bool ValidateRemoteCertificate(object Sender, X509Certificate Certificate, X509Chain Chain, SslPolicyErrors PolicyErrors)
            {
                ...
            }
