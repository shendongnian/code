    public static WinZipAesCrypto Generate(string password, int KeyStrengthInBits)
    {
        WinZipAesCrypto c = new WinZipAesCrypto(password, KeyStrengthInBits);
        int saltSizeInBytes = c._KeyStrengthInBytes / 2;
        c._Salt = new byte[saltSizeInBytes];
        Random rnd = new Random();
        rnd.NextBytes(c._Salt);
        return c;
    }
