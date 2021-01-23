    // Initialize the byte array
    string sourceNoBlanks = source.Replace(" ", "");
    byte[] sourceBytes = new byte[source.Length / 2];
    // Then, create the bytes
    for (int i = 0; i < sourceBytes.Length; i++)
    {
        string byteString = sourceNoBlanks.Substring(i*2, 2);
        sourceBytes[i] = Byte.Parse(byteString, NumberStyles.HexNumber);
    }
