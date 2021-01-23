    private static readonly int[] charOffsets = new[]{30,26,39,...};
    private static char EncryptChar(char c, int index)
    {
        return (char)(c + charOffests[index % charOffsets.Length]);
    }
    private static char DecryptChar(char c, int index)
    {
        return (char)(c - charOffests[index % charOffsets.Length]);
    }
    public static string Encrypt(string str)
    {
        return new string(str.Select((c, i) => EncryptChar(c, i)));
    }
    public static string Decrypt(string str)
    {
        return new string(str.Select((c, i) => DecryptChar(c, i)));
    }
