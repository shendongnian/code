    using System.Security.Cryptography;
    using System.Text;
    
    internal static string FaceBookSecret(string content, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] messageBytes = Encoding.UTF8.GetBytes(content);
        HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes);
        byte[] hash = hmacsha256.ComputeHash(messageBytes);
        StringBuilder sbHash = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        { sbHash.Append(hash[i].ToString("x2")); }
        return sbHash.ToString();
    }
