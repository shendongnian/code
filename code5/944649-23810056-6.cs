    private static byte[] StringToBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
    private static string BytesToString(byte[] bytes)
    {
        char[] chars = new char[bytes.Length / sizeof(char)];
        System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        return new string(chars);
    }
    public static string Encrypt(bool encrypt, string word, int startKey, int multKey, int addKey)
    {
        try
        {
            byte[] source = StringToBytes(word);
            byte[] result = new byte[source.Length];
            for (int i = 0; i < source.Length; ++i)
            {
                result[i] = (byte)((word[i] ^ (startKey >> 8)) & 0xFF);
                if (encrypt)
                    startKey = ((result[i]) + startKey) * multKey + addKey;
                else
                    startKey = ((word[i]) + startKey) * multKey + addKey;
            }
            return BytesToString(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
