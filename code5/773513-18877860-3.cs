    private int SQLBinaryChecksum(string text)
    {
        long sum = 0;
        byte overflow;
        for (int i = 0; i < text.Length; i++)
        {
            sum = (long)((16 * sum) ^ Convert.ToUInt32(text[i]));
            overflow = (byte)(sum / 4294967296);
            sum = sum - overflow * 4294967296;
            sum = sum ^ overflow;
        }
        if (sum > 2147483647)
            sum = sum - 4294967296;
        else if (sum >= 32768 && sum <= 65535)
            sum = sum - 65536;
        else if (sum >= 128 && sum <= 255)
            sum = sum - 256;
        return (int)sum;
    }
