    public class ImpersonateUserClass
    {
        public static IntPtr ImpersonateUser(string sUsername, string sDomain, string sPassword)
        {
            // initialize tokens
            var pExistingTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            IntPtr token = IntPtr.Zero;
            // if domain name was blank, assume local machine
            if (sDomain == "")
            {
                sDomain = Environment.MachineName;
            }
            try
            {
                unsafe
                {
                    const int LOGON32_PROVIDER_DEFAULT = 0;
                    bool bImpersonated = NativMethodes.LogonUser(sUsername, sDomain, sPassword,
                                         (int) NativMethodes.LOGON_TYPE.LOGON32_LOGON_BATCH, 
                                         LOGON32_PROVIDER_DEFAULT,
                                         out pExistingTokenHandle);
                    // did impersonation fail?
                    if (false == bImpersonated)
                    {
                        throw new Win32Exception("bImpersonated");
                    }
                    bool bRetVal = NativMethodes.DuplicateTokenEx(pExistingTokenHandle,
                        0,
                        null,
                        NativMethodes.SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation,
                        NativMethodes.TOKEN_TYPE.TokenPrimary,
                        out token);
                    // did DuplicateToken fail?
                    if (false == bRetVal)
                    {
                        int nErrorCode = Marshal.GetLastWin32Error();
                        // close existing handle
                        NativMethodes.CloseHandle(pExistingTokenHandle);
                        throw new Win32Exception("bRetVal");
                    }
                    else
                        return token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close handle(s)
                if (pExistingTokenHandle != IntPtr.Zero)
                    NativMethodes.CloseHandle(pExistingTokenHandle);
            }
        }
