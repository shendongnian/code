    public BigInteger ComputeSharedSecret(string A, AsymmetricKeyParameter bPrivateKey, DHParameters internalParameters)
    {
        var importedKey = new DHPublicKeyParameters(new BigInteger(A), internalParameters);
        var internalKeyAgree = AgreementUtilities.GetBasicAgreement("DH");
        internalKeyAgree.Init(bPrivateKey);
        return internalKeyAgree.CalculateAgreement(importedKey);
    }
