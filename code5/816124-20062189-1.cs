    public static String unwrapKey(String toUnwrap, String key)
    {
        byte[] decoded = Convert.FromBase64String(toUnwrap);
        if (decoded == null || decoded.Length <= 16)
        {
            throw new System.ArgumentException("Bad input data", "toUnwrap");
        }
        byte[] salt = new byte[16];
        byte[] wrappedKey = new byte[decoded.Length - 16];
        Array.Copy(decoded, 0, salt, 0, 16);
        Array.Copy(decoded, 16, wrappedKey, 0, decoded.Length - 16);
        int iterationCount = 10;
        String algSpec = "AES/GCM/NoPadding";
        String algName = "PBEWithSHA256And256BitAES-CBC-BC";
    
        Asn1Encodable defParams = PbeUtilities.GenerateAlgorithmParameters(algName, salt, iterationCount);
        char[] password = key.ToCharArray();
        IWrapper wrapper = WrapperUtilities.GetWrapper(algSpec);
        ICipherParameters parameters = PbeUtilities.GenerateCipherParameters(algName, password, defParams);
        wrapper.Init(false, parameters);
        byte[] keyText = wrapper.Unwrap(wrappedKey, 0, wrappedKey.Length);
        return Convert.ToBase64String(keyText);
    }
