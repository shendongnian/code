    private static RSACryptoServiceProvider UpgradeCsp(RSACryptoServiceProvider currentKey)
    {
        const int PROV_RSA_AES = 24;
        CspKeyContainerInfo info = currentKey.CspKeyContainerInfo;
        // WARNING: 3rd party providers and smart card providers may not handle this upgrade.
        // You may wish to test that the info.ProviderName value is a known-convertible value.
        CspParameters cspParameters = new CspParameters(PROV_RSA_AES)
        {
            KeyContainerName = info.KeyContainerName,
            KeyNumber = (int)info.KeyNumber,
            Flags = CspProviderFlags.UseExistingKey,
        };
        if (info.MachineKeyStore)
        {
            cspParameters.Flags |= CspProviderFlags.UseMachineKeyStore;
        }
        if (info.ProviderType == PROV_RSA_AES)
        {
            // Already a PROV_RSA_AES, copy the ProviderName in case it's 3rd party
            cspParameters.ProviderName = info.ProviderName;
        }
        return new RSACryptoServiceProvider(cspParameters);
    }
