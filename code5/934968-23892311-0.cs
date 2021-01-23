    [Test]
    public void testSha256SignWithGoogleKey()
    {
        var cert = new X509Certificate2(@"....41e34b980643fd5b21-privatekey.p12", "notasecret", X509KeyStorageFlags.Exportable);
    
        byte[] data = new byte[] { 0, 1, 2, 3, 4, 5 };
    
        using (RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PrivateKey)
        {
            using (RSACryptoServiceProvider myRsa = new RSACryptoServiceProvider())
            {
                myRsa.ImportParameters(rsa.ExportParameters(true));
    
                byte[] signature = myRsa.SignData(data, "SHA256");
    
                if (myRsa.VerifyData(data, "SHA256", signature))
                {
                    Console.WriteLine("RSA-SHA256 signature verified");
                }
                else
                {
                    Console.WriteLine("RSA-SHA256 signature failed to verify");
                }
            }
        }
    }  
  
