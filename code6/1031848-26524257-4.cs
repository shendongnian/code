    //Decode from base 64
    byte[] publicKeyByte = Convert.FromBase64String(rsaPublicKey.modulo);
    byte[] exponentByte = Convert.FromBase64String(rsaPublicKey.exponent);
    //Convert to ASCII string
    UTF8Encoding ByteConverter = new UTF8Encoding();
    string publicKeyString = System.Text.Encoding.Default.GetString(publicKeyByte);
    string exponentString = System.Text.Encoding.Default.GetString(exponentByte);
    //Convert to BigInteger
    BigInteger publicKeyBI = BigInteger.Parse(publicKeyString);
    BigInteger exponentBI = BigInteger.Parse(exponentString);
    //Convert back to byte array
    byte[] publicKeyByte2 = publicKeyBI.ToByteArray();
    byte[] exponentByte2 = exponentBI.ToByteArray();
    //We must remove the 129th sign byte which is added when converting to BigInteger
    if (publicKeyByte2.Length == 129) Array.Resize(ref publicKeyByte2, 128);
    //Create crypto service
    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
    RSAParameters RSAKeyInfo = new RSAParameters();
    //Assign RSA key modulus/exponent reversing from little endian to big endian
    RSAKeyInfo.Modulus = publicKeyByte2.Reverse().ToArray();
    RSAKeyInfo.Exponent = exponentByte2.Reverse().ToArray();
    RSA.ImportParameters(RSAKeyInfo);
    //Convert password string to byte array
    byte[] passwordByte = ByteConverter.GetBytes(clearPassword);
    //Encrypt the password and encode 64
    encryptedPassword = Convert.ToBase64String(RSA.Encrypt(passwordByte, false));
