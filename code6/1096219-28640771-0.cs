    public static string MD5Hash(this string s)
    {
        using (MD5CryptoServiceProvider csp = new MD5CryptoServiceProvider())
        {
            unsafe
            {
                fixed (char* input = s)
                {
                    using (var stream = new UnmanagedMemoryStream((byte*)input, sizeof(char) * s.Length))
                        return Convert.ToBase64String(csp.ComputeHash(stream)); 
                }
            }
        }
    }
