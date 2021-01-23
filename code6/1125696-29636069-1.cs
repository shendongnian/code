    static string SecureComputeHash(string username, SecureString password)
    {
        byte[] textBytes = null;
        IntPtr textChars = IntPtr.Zero;
        try
        {
            byte[] userNameBytes = Encoding.Unicode.GetBytes(username);
            textChars = Marshal.SecureStringToGlobalAllocUnicode(password);
            int passwordByteLength = password.Length * 2;
            textBytes = new byte[userNameBytes.Length + passwordByteLength];
            userNameBytes.CopyTo(textBytes, 0);
            Marshal.Copy(textChars, textBytes, userNameBytes.Length, passwordByteLength);
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return Convert.ToBase64String(provider.ComputeHash(textBytes));
            }
        }
        finally
        {
            // Clean up temporary buffers
            if (textChars != IntPtr.Zero)
            {
                Marshal.ZeroFreeGlobalAllocUnicode(textChars);
            }
            if (textBytes != null)
            {
                for (int i = 0; i < textBytes.Length; i++)
                {
                    textBytes[i] = 0;
                }
            }
        }
    }
