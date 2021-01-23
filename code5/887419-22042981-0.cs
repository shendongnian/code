    public static string encryptXOREng(string plainText, string keyText)
    {
        List<byte> chiffreText = new List<byte>();    
        byte[] binaryPlainText = System.Text.Encoding.ASCII.GetBytes(plainText);
        byte[] binaryKeyText = System.Text.Encoding.ASCII.GetBytes(keyText);
        for (int i = 0; i < plainText.Length; i++)
        {
            int result = binaryPlainText[i] ^ binaryKeyText[i % binaryKeyText.Length];
            chiffreText.Add((byte)result);
        }
        return Convert.ToBase64String(chiffreText.ToArray());
    }
