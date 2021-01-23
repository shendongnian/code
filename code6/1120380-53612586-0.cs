    public bool VerifySignature(AsymmetricKeyParameter pubKey, string signature, string msg)
    {
        try
        {
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            byte[] sigBytes = Convert.FromBase64String(signature);
            ISigner signer = SignerUtilities.GetSigner("SHA-256withRSA");
            signer.Init(false, pubKey);
            signer.BlockUpdate(msgBytes, 0, msgBytes.Length);
            return signer.VerifySignature(sigBytes);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Verification failed with the error: " + exc.ToString());
            return false;
        }
    }
