    var credential = new NetworkCredential(username, password);
    string message = _client.Connect(hostname, port, credential, 
        ESSLSupportMode.Implicit,
        null, // new RemoteCertificateValidationCallback(ValidateTestServerCertificate), 
        null, 0, 0, 0, null); 
