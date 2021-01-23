    using System.ServiceModel; // (to ChannelFactory)
    using System.IdentityModel;  
    
    ConfigChannel = new ChannelFactory<xxxxxx>(binding, endPoint);
    ConfigChannel.Credentials.UserName.UserName = _userName;
    ConfigChannel.Credentials.UserName.Password = _password;
    
    ConfigChannel.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
