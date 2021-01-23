    public static void Main(string[] args)
    {
        var c = "abc☰def";
        var b = Encoding.UTF8.GetBytes(c);
        var result = DecodeFromStream(new MemoryStream(b), Encoding.UTF8, 3);
        Console.WriteLine(result);
        Console.WriteLine(c == result);
    }
        
    private static string DecodeFromStream(Stream dataStream, Encoding encoding, int bufferSize)
    {
        Decoder decoder = encoding.GetDecoder();
        StringBuilder sb = new StringBuilder();
        int inputByteCount;
        byte[] inputBuffer = new byte[bufferSize];
        char[] charBuffer = new char[encoding.GetMaxCharCount(inputBuffer.Length)];
        while ((inputByteCount = dataStream.Read(inputBuffer, 0, inputBuffer.Length)) > 0)
        {                   
           int readChars = decoder.GetChars(inputBuffer, 0, inputByteCount, charBuffer, 0);
           if (readChars > 0)
               sb.Append(charBuffer, 0, readChars);
        }
        return sb.ToString();
    }
