            var machineName = Environment.MachineName;
            var keyCreationParameters = new CngKeyCreationParameters();
            keyCreationParameters.KeyUsage = CngKeyUsages.AllUsages;
            keyCreationParameters.KeyCreationOptions = CngKeyCreationOptions.OverwriteExistingKey;
            keyCreationParameters.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(4096), CngPropertyOptions.None));
            var cngKey = CngKey.Create(CngAlgorithm2.Rsa, "Test", keyCreationParameters);
            var x500DistinguishedName = new X500DistinguishedName("CN=" + machineName);
            x500DistinguishedName.Oid.Value = "1.3.6.1.5.5.7.3.1";
            var certificateCreationParameters = new X509CertificateCreationParameters(x500DistinguishedName);
            certificateCreationParameters.SignatureAlgorithm = X509CertificateSignatureAlgorithm.RsaSha512;
            certificateCreationParameters.TakeOwnershipOfKey = true;
            certificateCreationParameters.CertificateCreationOptions = X509CertificateCreationOptions.None;
            certificateCreationParameters.EndTime = new DateTime(9999, 12,31, 23, 59, 59, 999, DateTimeKind.Utc);
            var certificate = cngKey.CreateSelfSignedCertificate(certificateCreationParameters);
            var certificateStore = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            certificateStore.Open(OpenFlags.ReadWrite);
            certificateStore.Add(certificate);
            certificateStore.Close();
            var tcpListener = TcpListener.Create(6666);
            tcpListener.Start();
            var client = new TcpClient("localhost", 6666);
            var acceptedClient = tcpListener.AcceptTcpClient();
            var acceptedClinetSslStream = new SslStream(
                acceptedClient.GetStream(), false);
            var serverAuthTask = acceptedClinetSslStream.AuthenticateAsServerAsync(certificate,
                                false, SslProtocols.Tls, true);
            SslStream clientSslStream = new SslStream(
                client.GetStream(),
                false,
                delegate(object o, X509Certificate x509Certificate, X509Chain chain, SslPolicyErrors errors)
                    {
                        if (errors == SslPolicyErrors.None)
                            return true;
                        Console.WriteLine("Certificate error: {0}", errors);
                        // Do not allow this client to communicate with unauthenticated servers. 
                        return false;
                    },
                null);
            var clientAuthTask = clientSslStream.AuthenticateAsClientAsync(machineName);
            Task.WaitAll(serverAuthTask, clientAuthTask);
