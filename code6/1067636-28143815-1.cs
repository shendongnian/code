    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.X509.Store;
    
    class Program
    {
      protected static byte[] SignWithSystem(byte[] data, AsymmetricKeyParameter key, X509Certificate cert, X509Certificate[] chain)
      {
        var generator = new CmsSignedDataGenerator();
        // Add signing key
        generator.AddSigner(
          key,
          cert,
          "2.16.840.1.101.3.4.2.1"); // SHA256 digest ID
        var storeCerts = new List<X509Certificate>();
        storeCerts.Add(cert); // NOTE: Adding end certificate too
        storeCerts.AddRange(chain); // I'm assuming the chain collection doesn't contain the end certificate already
        // Construct a store from the collection of certificates and add to generator
        var storeParams = new X509CollectionStoreParameters(storeCerts);
        var certStore = X509StoreFactory.Create("CERTIFICATE/COLLECTION", storeParams);
        generator.AddCertificates(certStore);
    
        // Generate the signature
        var signedData = generator.Generate(
          new CmsProcessableByteArray(data),
          false); // encapsulate = false for detached signature
        return signedData.GetEncoded();
      }
    
      static void Main(string[] args)
      {
        try
        {
          // Load end certificate and signing key
          AsymmetricKeyParameter key;
          var signerCert = ReadCertFromFile(@"C:\Temp\David.p12", "pin", out key);
    
          // Read CA cert
          var caCert = ReadCertFromFile(@"C:\Temp\CA.cer");
          var certChain = new X509Certificate[] { caCert };
    
          var result = SignWithSystem(
            Guid.NewGuid().ToByteArray(), // Any old data for sake of example
            key,
            signerCert,
            certChain);
    
          File.WriteAllBytes(@"C:\Temp\Signature.data", result);
        }
        catch (Exception ex)
        {
          Console.WriteLine("Failed : " + ex.ToString());
          Console.ReadKey();
        }
      }
    
      public static X509Certificate ReadCertFromFile(string strCertificatePath)
      {
        // Create file stream object to read certificate
        using (var keyStream = new FileStream(strCertificatePath, FileMode.Open, FileAccess.Read))
        {
          var parser = new X509CertificateParser();
          return parser.ReadCertificate(keyStream);
        }
      }
    
      // This reads a certificate from a file.
      // Thanks to: http://blog.softwarecodehelp.com/2009/06/23/CodeForRetrievePublicKeyFromCertificateAndEncryptUsingCertificatePublicKeyForBothJavaC.aspx
      public static X509Certificate ReadCertFromFile(string strCertificatePath, string strCertificatePassword, out AsymmetricKeyParameter key)
      {
        key = null;
        // Create file stream object to read certificate
        using (var keyStream = new FileStream(strCertificatePath, FileMode.Open, FileAccess.Read))
        {
          // Read certificate using BouncyCastle component
          var inputKeyStore = new Pkcs12Store();
          inputKeyStore.Load(keyStream, strCertificatePassword.ToCharArray());
    
          var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));
    
          // Read Key from Aliases  
          if (keyAlias == null)
            throw new NotImplementedException("Alias");
          key = inputKeyStore.GetKey(keyAlias).Key;
          //Read certificate into 509 format
          return (X509Certificate)inputKeyStore.GetCertificate(keyAlias).Certificate;
        }
      }
    }
