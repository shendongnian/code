    public bool verifySignature(byte[] signatureBytes, String message)
    {
      AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)new PemReader(newStringReader(PUBLIC_KEY)).ReadObject();
      ISigner sig = SignerUtilities.GetSigner("SHA1withRSA");
      sig.Init(false, publicKey);
    
      byte[] messageBytes = Encoding.ASCII.GetBytes(message);
      sig.BlockUpdate(messageBytes, 0, messageBytes.Length);
      return sig.VerifySignature(signatureBytes);
    }
