    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    class Example
    {
        private RSACryptoServiceProvider publicKey,
                                         privateKey;
        private bool getRSAKeys(X509Certificate2 cert, StoreLocation location)
        {
            try
            {
                //This will throw a CryptographicException if the certificate is expired
                publicKey = (RSACryptoServiceProvider)cert.PublicKey.Key;
                privateKey = (RSACryptoServiceProvider)cert.PrivateKey;
                return true;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("The certificate is expired or otherwise unusable\r\n" + e.ToString());
                return false;
            }
        }
