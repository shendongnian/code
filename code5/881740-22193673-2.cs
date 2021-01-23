    ServicePointManager.ServerCertificateValidationCallback = delegate(
                Object obj, X509Certificate certificate, X509Chain chain, 
                SslPolicyErrors errors)
                {
                    if (errors == SslPolicyErrors.RemoteCertificateNameMismatch)
                    {
                      return (true);
                    }
                };
