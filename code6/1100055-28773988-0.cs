    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    
    namespace SignWithToken
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ------ select certificate for signing ---------
                // open store
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.MaxAllowed);
    
                // find cert by thumbprint
                var foundCerts = store.Certificates.Find(X509FindType.FindByThumbprint, "44 df b8 96 73 55 e4 e2 56 3a c0 a2 e0 66 8e 52 8a 3a 4a f4", true);
    
                if (foundCerts.Count == 0)
                    return;
    
                var certForSigning = foundCerts[0];
                store.Close();
    
                // -------- prepare private key with password --------
                // prepare password
                var pass = new SecureString();
                for(var i=0;i<8;i++)
                    pass.AppendChar('1');
    
                // take private key
                var privateKey = certForSigning.PrivateKey as RSACryptoServiceProvider;
    
                // make new CSP parameters based on parameters from current private key but throw in password
                CspParameters cspParameters = new CspParameters(privateKey.CspKeyContainerInfo.ProviderType,
                    privateKey.CspKeyContainerInfo.ProviderName,
                    privateKey.CspKeyContainerInfo.KeyContainerName,
                    null,
                    pass);
    
                // make RSA crypto provider based on given CSP parameters
                var rsaCsp = new RSACryptoServiceProvider(cspParameters);
                
                // set modified RSA crypto provider back
                certForSigning.PrivateKey = rsaCsp;
    
                // ---- Sign -----
                // prepare content to be signed
                ContentInfo content = new ContentInfo(new byte[] {0x01, 0x02, 0x03});
                SignedCms cms = new SignedCms(content);
                
                // prepare CMS signer 
                CmsSigner signer = new CmsSigner(certForSigning);
    
                // sign to PKCS#7
                cms.ComputeSignature(signer);
    
                // get encoded PKCS#7 value
                var result = cms.Encode();
    
                // ------ Verify signature ------
                SignedCms cmsToVerify = new SignedCms();
                // decode signed PKCS#7
                cmsToVerify.Decode(result);
    
                // check signature of PKCS#7
                cmsToVerify.CheckSignature(true);
            }
        }
    }
