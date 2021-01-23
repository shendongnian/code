    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateCert);
 
    public static bool ValidateCert(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        string requestHost;
        if(sender is string)
        {
            requestHost = sender.ToString();
        }
        else
        {
            HttpWebRequest request = sender as HttpWebRequest;
            
            if(request != null)
            {
                requestHost = request.Host;
            }
        }
        if(!string.IsNullOrEmpty(requestHost) && requestHost == "my_test_machine")
            return true;
 
        return sslPolicyErrors == SslPolicyErrors.None;
    }
