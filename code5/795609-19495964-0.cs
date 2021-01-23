    private static void Main(string[] args) {
        var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
        string byteOrderMark = encoding.GetString(encoding.GetPreamble());
        Console.WriteLine("Hello".StartsWith(byteOrderMark, StringComparison.Ordinal));
        Console.WriteLine("Hello".StartsWith("\ufeff", StringComparison.Ordinal));
        Console.WriteLine("Hello"[0] == '\ufeff');
        Console.ReadKey();
    }
