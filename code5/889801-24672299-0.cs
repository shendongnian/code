    X509Certificate2 cert = new X509Certificate2(@"c:\temp\FILENAME.pfx", "PASSWORD", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
    RSACryptoServiceProvider provider = (RSACryptoServiceProvider)cert.PrivateKey;
    if (provider.KeyExchangeAlgorithm != null)
    	throw new Exception("Supplied file has not been generated for signing using the -keysig argument with openssl");
    byte[] array = provider.ExportCspBlob(!provider.PublicOnly);
    using (FileStream fs = new FileStream(@"c:\temp\FILENAME.snk", FileMode.Create, FileAccess.Write)) {
    	fs.Write(array, 0, array.Length);
    }
