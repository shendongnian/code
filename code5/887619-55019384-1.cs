    public static IEnumerable<byte> Encode(IEnumerable<string> input, Encoding encoding)
    {
        byte[] newLine = encoding.GetBytes(Environment.NewLine);
        foreach (string line in input)
        {
            byte[] bytes = encoding.GetBytes(line);
            foreach (byte b in bytes)
                yield return b;
            foreach (byte b in newLine)
                yield return b;
        }
    }
