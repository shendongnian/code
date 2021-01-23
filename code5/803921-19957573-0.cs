    private static string Encode(string text)
    {
        byte[] result = Encoding.ASCII.GetBytes(text);
        int[] values = new int[result.Length];
        for (int i = 0; i < text.Length; i++)
        {
            result[i] = (byte)(Convert.ToInt32(text[i]) ^ 42);
        }
        return Convert.ToBase64String(result);
    }
    private static string Decode(string text)
    {
        byte[] result = Convert.FromBase64String(text);
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (byte)(result[i] ^ 42);
        }
        return Encoding.ASCII.GetString(result);
    }
