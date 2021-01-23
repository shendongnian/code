    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CryptAcquireContext(out IntPtr phProv, string pszContainer, string pszProvider, uint dwProvType, uint dwFlags);
            
    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CryptSetProvParam(IntPtr hProv, uint dwParam, [In] byte[] pbData, uint dwFlags);
    
    [DllImport("advapi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CryptReleaseContext(IntPtr hProv, uint dwFlags);
            
    const string MS_DEF_PROV = "Microsoft Base Cryptographic Provider v1.0";
    const uint NTE_BAD_KEYSET = 0x80090016;
    const uint PROV_RSA_FULL = 1;
    const uint CRYPT_VERIFYCONTEXT = 0xF0000000;
    const uint CRYPT_NEWKEYSET = 0x00000008;
    const uint PP_PIN_PROMPT_STRING = 0x2C;
            
    public unsafe void SetPinText(string text)
    {
        byte[] data = Encoding.UTF8.GetBytes(text);
        
        IntPtr hCryptProv;
    
        try
        {
            if (!CryptAcquireContext(out hCryptProv, null, MS_DEF_PROV, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT))
            {
                if (Marshal.GetLastWin32Error() == NTE_BAD_KEYSET)
                {
                    if (!CryptAcquireContext(out hCryptProv, null, null, PROV_RSA_FULL, CRYPT_NEWKEYSET))
                        throw new Exception("Unable to acquire crypt context.");
                }
                else
                {
                    throw new Exception("Unable to acquire crypt context.");
                }
            }
        
            if (!CryptSetProvParam(hCryptProv, PP_PIN_PROMPT_STRING, DataColumn, 0))
                throw new Exception("Unable to set prompt string.");
        }
        finally
        {
            if (hCryptProv != IntPtr.Zero)
            {
                CryptReleaseContext(hCryptProv, 0);
            }
        }
    }
