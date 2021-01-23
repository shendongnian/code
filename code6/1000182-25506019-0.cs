    chain = new X509Chain();
    chain.ChainPolicy.RevocationMode = m_CheckCertRevocation? X509RevocationMode.Online : X509RevocationMode.NoCheck;
    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
    if (remoteCertificateStore != null)
       chain.ChainPolicy.ExtraStore.AddRange(remoteCertificateStore);
    if (!chain.Build(remoteCertificateEx)       // Build failed on handle or on policy
       && chain.ChainContext == IntPtr.Zero)   // Build failed to generate a valid handle
    {
        throw new CryptographicException(Marshal.GetLastWin32Error());
    }
