    public static void SetIdentity(string subId)
    {
        if (Proxy.ClientCredentials != null && Proxy.ClientCredentials.UserName != null)
        {
            Proxy.ClientCredentials.UserName.UserName = subId;// 
            Proxy.ClientCredentials.UserName.Password = subId;
        }
        ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(customXertificateation);
    }
