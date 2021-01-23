    public static string EncrypIt(string password, string publicKey, string exponent) {
    //Decode from base 64
    byte[] publicKeyByte = Convert.FromBase64String(publicKey);
    byte[] exponentByte = Convert.FromBase64String(exponent);
    //Convert to ASCII string
    //ASCIIEncoding ByteConverter = new ASCIIEncoding();
    UTF8Encoding ByteConverter = new UTF8Encoding();
    string publicKeyString = System.Text.Encoding.Default.GetString(publicKeyByte);
    string exponentString = System.Text.Encoding.Default.GetString(exponentByte);
    //Convert to BigInteger
    BigInteger publicKeyBI = BigInteger.Parse(publicKeyString);
    BigInteger exponentBI = BigInteger.Parse(exponentString);
    //Convert back to byte array
    byte[] publicKeyByte2 = publicKeyBI.ToByteArray();
    byte[] exponentByte2 = exponentBI.ToByteArray();
    //Create crypto service
    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
    RSAParameters RSAKeyInfo = new RSAParameters();
    RSAKeyInfo = RSA.ExportParameters(false); //Export only public key
    //Set RSAKeyInfo to the public key values. 
    RSAKeyInfo.Modulus = publicKeyByte2.Reverse().ToArray();
    RSAKeyInfo.Exponent = exponentByte2.Reverse().ToArray();
    RSA.ImportParameters(RSAKeyInfo);
    //Convert password string to byte array
    byte[] passwordByte = ByteConverter.GetBytes(password);
    byte[] encryptedPassword = RSA.Encrypt(passwordByte, false);
    //Return encoded 64 encrypted password
    return Convert.ToBase64String(encryptedPassword);
