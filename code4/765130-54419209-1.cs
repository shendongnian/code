    public static Task SkipLinesAsync(this TextReader reader, int linesToSkip)
	{
		if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
		if (linesToSkip < 0) { throw new ArgumentOutOfRangeException(nameof(linesToSkip)); }
		return reader.SkipLinesInternalAsync(linesToSkip);
	}
    private static async Task SkipLinesInternalAsync(this TextReader reader, int linesToSkip)
	{
		for (var i = 0; i < linesToSkip; ++i)
		{
			var line = await reader.ReadLineAsync().ConfigureAwait(false);
			if (line == null) { break; }
		}
	}
