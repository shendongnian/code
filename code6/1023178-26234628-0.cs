    protected static string Base64ForUrlEncode(string str)
            {
    
                StringBuilder result = new StringBuilder(Convert.ToBase64String(Encoding.ASCII.GetBytes(str)).TrimEnd('='));
                result.Replace('+', '-');
                result.Replace('/', '_');
                return result.ToString();
            }
    protected static byte[] GetBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
