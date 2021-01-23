    public static class SecurePassword
    {
        #region Fields
        static byte[] _entropy = System.Text.Encoding.Unicode.GetBytes("Db Config Password");
        #endregion
        #region Methods
   
        public static SecureString GetSecureString(string password)
        {
            SecureString secureString = new SecureString();
            foreach (char c in password)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }
  
        public static string GetInsecureString(SecureString securePassword)
        {
            string password = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(securePassword);
            try
            {
                password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return password;
        }
    
        public static string EncryptString(SecureString securePassword)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                    System.Text.Encoding.Unicode.GetBytes(GetInsecureString(securePassword)),
                    _entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }
  
        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    _entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return GetSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }
        #endregion
    }
