    RsaPrivateCrtKeyParameters privateKeyParameters = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(prvKey));
    AsymmetricKeyParameter publicKeyInfoParameters = PublicKeyFactory.CreateKey(Convert.FromBase64String(pubKey));
    byte[] clearData = Encoding.UTF8.GetBytes("...");
    string algorithm = "RSA/ECB/PKCS1Padding";
    var cipherOne = Org.BouncyCastle.Security.CipherUtilities.GetCipher(algorithm);
    cipherOne.Init(true, privateKeyParameters);
    byte[] signedData = cipherOne.DoFinal(clearData);
    
    var clientTwo = CipherUtilities.GetCipher(algorithm);
    clientTwo.Init(false, publicKeyInfoParameters);
    var clearDataTwo = clientTwo.DoFinal(signedData);
    Assert.IsTrue(Convert.ToBase64String(clearData) == Convert.ToBase64String(clearDataTwo));
