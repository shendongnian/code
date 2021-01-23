    static BigInteger ConvertToBigInteger(string input)
    {
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes(input);
        // BigInteger constructor expects a little-endian byte array
        Array.Reverse(bytes);
        return new BigInteger(bytes);
    }
        
    static BigInteger ConvertToBigInteger(string input)
    {
        BigInteger sum = 0;
        foreach (char c in input)
        {
            sum = (sum << 16) + (int) c;
        }
        return sum;
    }
