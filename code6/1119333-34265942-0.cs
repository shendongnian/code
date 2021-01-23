    using System.ServiceModel; // (to ChannelFactory)
    using System.IdentityModel;  //(to enum X509CertificateValidationMode)
    
    ConfigChannel = new ChannelFactory<xxxxxx>(binding, endPoint);
    ConfigChannel.Credentials.UserName.UserName = _userName;
    ConfigChannel.Credentials.UserName.Password = _password;
    
    ConfigChannel.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = **X509CertificateValidationMode.None**;
