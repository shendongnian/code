    using System.Net;
    bool isSelfSignedCertificate = Convert.ToBoolean(ConfigurationManager.AppSettings["isSelfSignedCertificate"]);
    if (isSelfSignedCertificate)
    {
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    }
