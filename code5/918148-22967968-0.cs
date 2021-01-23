    /// <summary>
    /// Sets the Certificate Validation Policy for the Client
    /// </summary>
    public static void SetCertificatePolicy()
    {
        ServicePointManager.ServerCertificateValidationCallback 
                                              += ValidateRemoteCertificate;
    }
    /// <summary>
    /// Allows for validation of SSL conversations with the server. 
    /// </summary>
    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, 
                                            X509Chain chain, SslPolicyErrors error)
    {
        if (cert.GetCertHashString() == "Your Certificate SHA1 HashString")
        {
           return true;
        }
        else
        {
           string text = "Failed to establish secure channel for SSL/TLS." 
                         + Environment.NewLine + Environment.NewLine +
                         "Connection with server has been disallowed.";
           MessageBox.Show(text, @"SSL Validation Failure", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           return false;
        }
    }
