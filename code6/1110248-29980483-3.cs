    // This returns A
    public string GetPublicKey(AsymmetricCipherKeyPair keyPair)
    {
        var dhPublicKeyParameters = _generatedKey.Public as DHPublicKeyParameters;
        if (dhPublicKeyParameters != null)
        {
            return dhPublicKeyParameters.Y.ToString();
        }
        throw new NullReferenceException("The key pair provided is not a valid DH keypair.");
    }
    // This returns a
    public string GetPrivateKey(AsymmetricCipherKeyPair keyPair)
    {
        var dhPrivateKeyParameters = _generatedKey.Private as DHPrivateKeyParameters;
        if (dhPrivateKeyParameters != null)
        {
            return dhPrivateKeyParameters.X.ToString();
        }
        throw new NullReferenceException("The key pair provided is not a valid DH keypair.");
    }
