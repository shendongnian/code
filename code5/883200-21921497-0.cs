    public static string Encode(string plainText)
    {
        byte[] numArray = System.Text.Encoding.Default.GetBytes(plainText);
        byte[] numArray1 = new byte[(int)numArray.Length + 1];
        // Generate a random byte as the seed used
        (new Random()).NextBytes(numArray1);
        byte num = (byte)(numArray1[0] ^ 188);
        numArray1[0] = numArray1[0];
        for (int i = 0; i < (int)numArray.Length; i++)
        {
            numArray1[i + 1] = (byte)(num ^ 188 ^ numArray[i]);
        }
        return Convert.ToBase64String(numArray1);
    }
