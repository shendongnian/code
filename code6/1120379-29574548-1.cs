        public void Program()
        {
            Console.WriteLine("Attempting to load cert...");
            System.Security.Cryptography.X509Certificates.X509Certificate2 thisCert = LoadCertificate();
            Console.WriteLine(thisCert.IssuerName.Name);
            Console.WriteLine("Signing the text - Mary had a nuclear bomb");
            byte[] pkcs12Bytes = thisCert.Export(X509ContentType.Pkcs12, "dummy");
            Pkcs12Store pkcs12 = new Pkcs12StoreBuilder().Build();
            pkcs12.Load(new MemoryStream(pkcs12Bytes, false), "dummy".ToCharArray());
            ECPrivateKeyParameters privKey = null;
            foreach (string alias in pkcs12.Aliases)
            {
                if (pkcs12.IsKeyEntry(alias))
                {
                    privKey = (ECPrivateKeyParameters)pkcs12.GetKey(alias).Key;
                    break;
                }
            }
            string signature = SignData("Mary had a nuclear bomb", privKey);
            Console.WriteLine("Signature: " + signature);
            Console.WriteLine("Verifying Signature");
            var bcCert = DotNetUtilities.FromX509Certificate(thisCert);
            if (VerifySignature((ECPublicKeyParameters)bcCert.GetPublicKey(), signature, "Mary had a nuclear bomb."))
                Console.WriteLine("Valid Signature!");
            else
                Console.WriteLine("Signature NOT valid!");
        }
