    public static string exclusiveOR(byte[] key, byte[] PAN)
    {
        if (key.Length == PAN.Length)
        {
            byte[] result = new byte[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                result[i] = (byte)(key[i] ^ PAN[i]);
            }
            string hex = BitConverter.ToString(result).Replace("-", "");
            return hex;
        }
        else
        {
            throw new ArgumentException();
        }
    }
