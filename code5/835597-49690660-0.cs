    internal class Protected
    {
        private  Byte[] salt = Guid.NewGuid().ToByteArray();
    
        protected byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, salt, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException)//no reason for hackers to know it failed
            {
    #if DEBUG
                throw;
    #else
                return null;
    #endif
            }
        }
    
        protected byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, salt, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException)//no reason for hackers to know it failed
            {
    #if DEBUG
                throw;
    #else
                return null;
    #endif
            }
        }
    }
