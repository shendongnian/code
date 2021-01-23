    public static string HexDigest(byte[] data)
    {
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            //format the bytes in hexadecimal
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
