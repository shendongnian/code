    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
     var keyBytes =
        Convert.FromBase64String(
          "MIIBI...."); // your key here
      AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
      RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
      RSAParameters rsaParameters = new RSAParameters();
      rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
      rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.ImportParameters(rsaParameters);
      byte[] plaintext = Encoding.UTF8.GetBytes("amount=1&currency=AED");
      byte[] ciphertext = rsa.Encrypt(plaintext, false);
      string cipherresult = Convert.ToBase64String(ciphertext);
