    public static string HexDigest(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));//formate the byte in hexa
            }
            return sBuilder.ToString();
        }
