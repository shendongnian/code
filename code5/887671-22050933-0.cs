    public static string GetHash(string text)
    {
        SHA512 alg = SHA512.Create();
        byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
        return Convert.ToBase64String(result);
    }
    
