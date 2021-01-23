    using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
    {
        byte[] buffer64bit = new byte[4];
        rng.GetBytes(buffer64bit);
        double value = BitConverter.ToDouble(buffer64bit, 0);
    }
