    public static string FormatAsHex(ReadOnlySpan<byte> data, int lineWidth = 16, int byteWidth = 1)
    {
        byte ReplaceControlCharacterWithDot(byte character) => character < 31 || character >= 127 ? (byte)46 /* dot */ : character;
        byte[] ReplaceControlCharactersWithDots(byte[] characters) => characters.Select(ReplaceControlCharacterWithDot).ToArray();
        IEnumerable<BigInteger> Chunk(IReadOnlyList<byte> source, int size) => source.Select((item, index) => source.Skip(size * index).Take(size).ToArray()).TakeWhile(bucket => bucket.Any()).Select(e => new BigInteger(e));
        var result = new StringBuilder();
        for(var pos = 0; pos < data.Length;)
        {
            var line = data.Slice(pos, Math.Min(lineWidth * byteWidth, data.Length - pos)).ToArray();
            var asHex = string.Join(" ", Chunk(line, byteWidth).Select(v => v.ToString("X" + byteWidth * 2, CultureInfo.InvariantCulture)));
            asHex += new string(' ', lineWidth * (byteWidth * 2 + 1) - 1 - asHex.Length);
            var asCharacters = Encoding.ASCII.GetString(ReplaceControlCharactersWithDots(line));
            result.Append(Invariant($"{pos:X4} {asHex} {asCharacters}\n"));
            pos += line.Length;
        }
        return result.ToString();
    }
