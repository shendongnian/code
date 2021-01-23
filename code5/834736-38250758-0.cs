    private static bool HasProtectedKey(X509Certificate2 cert)
    {
        if (!cert.HasPrivateKey)
        {
            return false;
        }
        using (RSA rsa = cert.GetRSAPrivateKey())
        {
            return HasProtectedKey(rsa);
        }
    }
    private static bool HasProtectedKey(RSA rsa)
    {
        RSACng rsaCng = rsa as RSACng;
        if (rsaCng != null)
        {
            return rsaCng.Key.UIPolicy.ProtectionLevel != CngUIProtectionLevels.None;
        }
        RSACryptoServiceProvider rsaCsp = rsa as RSACryptoServiceProvider;
        if (rsaCsp != null)
        {
            CspKeyContainerInfo info = rsaCsp.CspKeyContainerInfo;
            // First, try with the CNG API, it can answer the question directly:
            try
            {
                var openOptions = info.MachineKeyStore
                    ? CngKeyOpenOptions.MachineKey
                    : CngKeyOpenOptions.UserKey;
                var cngProvider = new CngProvider(info.ProviderName);
                using (CngKey cngKey =
                    CngKey.Open(info.KeyContainerName, cngProvider, openOptions))
                {
                    return cngKey.UIPolicy.ProtectionLevel != CngUIProtectionLevels.None;
                }
            }
            catch (CryptographicException)
            {
            }
            // Fallback for CSP modules which CNG cannot load:
            try
            {
                CspParameters silentParams = new CspParameters
                {
                    KeyContainerName = info.KeyContainerName,
                    KeyNumber = (int)info.KeyNumber,
                    ProviderType = info.ProviderType,
                    ProviderName = info.ProviderName,
                    Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.NoPrompt,
                };
                if (info.MachineKeyStore)
                {
                    silentParams.Flags |= CspProviderFlags.UseMachineKeyStore;
                }
                using (new RSACryptoServiceProvider(silentParams))
                {
                }
                return false;
            }
            catch (CryptographicException e)
            {
                const int NTE_SILENT_CONTEXT = unchecked((int)0x80090022);
                if (e.HResult == NTE_SILENT_CONTEXT)
                {
                    return true;
                }
                throw;
            }
        }
        // Some sort of RSA we don't know about, assume false.
        return false;
    }
