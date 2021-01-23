            string address = _managementServiceAddress;
            EndpointAddress epa = new EndpointAddress(new Uri(address), EndpointIdentity.CreateDnsIdentity("localhost"));
            ManagementWebServiceClient ds = new ManagementWebServiceClient("C24ServerAdminManagementEndpoint", epa);
            ds.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode  = X509CertificateValidationMode.None;
            ds.ClientCredentials.UserName.UserName = UserName;
            ds.ClientCredentials.UserName.Password = Password;
