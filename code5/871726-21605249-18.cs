    public async static Task ReadExactBytesAsync(
        Stream stream, byte[] buffer, CancellationToken ct)
    {
        var count = buffer.Length;
        var totalBytesRemaining = count;
        var totalBytesRead = 0;
        while (totalBytesRemaining != 0)
        {
            var bytesRead = await stream.ReadAsync(
                buffer, totalBytesRead, totalBytesRemaining, ct);
            ct.ThrowIfCancellationRequested();
            totalBytesRead += bytesRead;
            totalBytesRemaining -= bytesRead;
        }
    }
