    public static void SetIdentity(string subId)
    {
        if (null != Proxy.ClientCredentials && null != Proxy.ClientCredentials.Username)
        {
            Proxy.ClientCredentials.UserName.UserName = subId;// 
            Proxy.ClientCredentials.UserName.Password = subId;
        }
        ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(customXertificateation);
    }
