    WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
    using (identity.Impersonate())
    {
        webClient.Credentials = CredentialCache.DefaultNetworkCredentials;
        webClient.UseDefaultCredentials = true;
    }
