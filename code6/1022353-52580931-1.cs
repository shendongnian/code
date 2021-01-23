    public static class BinaryVisualiser
    {
        public static string FormatAsHex(ReadOnlySpan<byte> data)
        {
            byte ReplaceControlCharacterWithDot(byte character) 
                => character < 31 || character >= 127 ? (byte)46 /* dot */ : character;
            byte[] ReplaceControlCharactersWithDots(byte[] characters) 
                => characters.Select(ReplaceControlCharacterWithDot).ToArray();
            var result = new StringBuilder();
            const int lineWidth = 16;
            for (var pos = 0; pos < data.Length;)
            {
                var line = data.Slice(pos, Math.Min(lineWidth, data.Length - pos)).ToArray();
                var asHex = string.Join(" ", line.Select(v => v.ToString("X2", CultureInfo.InvariantCulture)));
                asHex += new string(' ', lineWidth * 3 - 1 - asHex.Length);
                var asCharacters = Encoding.ASCII.GetString(ReplaceControlCharactersWithDots(line));
                result.Append(FormattableString.Invariant($"{pos:X4} {asHex} {asCharacters}\n"));
                pos += line.Length;
            }
            return result.ToString();
        }
    }
