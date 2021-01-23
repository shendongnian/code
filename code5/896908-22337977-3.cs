    public static int getRandomNumber(int maxNumber)
    {
        if (maxNumber < 1)
            throw new System.Exception("The maxNumber value should be greater than 1");
        byte[] b = new byte[4];
        new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
        int seed = (b[0] & 0x7f) << 24 | b[1] << 16 | b[2] << 8 | b[3];
        return seed % maxNumber;
    }
