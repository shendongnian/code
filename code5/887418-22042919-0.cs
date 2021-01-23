    public static byte[] XORCipher(string plainText, string keyText)
    {
        byte[] binaryPlainText = System.Text.Encoding.ASCII.GetBytes(plainText);
        byte[] binaryKeyText = System.Text.Encoding.ASCII.GetBytes(keyText);
        for(int i = 0;i<plainText.Length;i++)
        {
        	binaryPlainText[i] ^= binaryKeyText[i];
        }
        return binaryPlainText;
    }
