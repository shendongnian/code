    public static async Task SkipLinesAsync(this TextReader reader, int linesToSkip) // Noncompliant
    {
        if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
        if (linesToSkip < 0) { throw new ArgumentOutOfRangeException(nameof(linesToSkip)); }
        for (var i = 0; i < linesToSkip; ++i)
        {
            var line = await reader.ReadLineAsync().ConfigureAwait(false);
            if (line == null) { break; }
        }
    }
