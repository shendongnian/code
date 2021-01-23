       public static string Encrypt(string fullMessage, string certificateName, bool deAttch)
        {
            X509Certificate2 signer = GetCertificate(certificateName);  
            byte[] contentBytes = Encoding.ASCII.GetBytes(fullMessage);  
            Oid contentOid = new Oid("1.2.840.113549.1.7.1", "PKCS 7 Data");
            SignedCms signedMessage = new SignedCms(new ContentInfo(contentOid, contentBytes), deAttch);
			CmsSigner cert = new CmsSigner(signer);
            cert.IncludeOption = X509IncludeOption.EndCertOnly;            
            signedMessage.ComputeSignature(cert);
            byte[] signedBytes = signedMessage.Encode();
			return Convert.ToBase64String(signedBytes).Trim();
			}
			
			
			private static X509Certificate2 GetCertificate(string certificateName)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
            X509Certificate2 certificate = store.Certificates.Cast<X509Certificate2>().Where(cert => cert.Subject.IndexOf(certificateName) >= 0).FirstOrDefault();
            if (certificate == null)
                throw new Exception("Certificate " + certificateName + " not found.");
            return certificate;
        }
