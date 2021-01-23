    if (ServicePointManager.ServerCertificateValidationCallback != null)
    {
        useDefault = false;
        return ServicePointManager.ServerCertValidationCallback.
                                   Invoke(m_Request,
                                          certificate,
                                          chain,
                                          sslPolicyErrors);
    }
 
    if (useDefault)
        return sslPolicyErrors == SslPolicyErrors.None;
